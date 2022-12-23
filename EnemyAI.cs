using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour{
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    public int health = 75;
    public float attackDamage = 10;
    private Rigidbody rb;

    private bool isDead = false;
    private UIManager _uiManager;
	private NavMeshAgent nm;
	public Transform target;
    public Transform brain;
    [SerializeField] private float viewDistance = 5F;
    [SerializeField] private float attackDistance = 1f;
	public enum AIState{target_brain,target_player,attacking_player,attacking_brain,death}
	public AIState aiState = AIState.target_brain;
	Animator charAnim;

    void Start(){
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    	charAnim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        brain = GameObject.FindGameObjectWithTag("Brain").transform;
    	nm = GetComponent<UnityEngine.AI.NavMeshAgent>();
    	StartCoroutine(Think());
        rb = GetComponent<Rigidbody>();
    }


    void HitByBullet(int damage){
        health -= damage;
        if (health < 1) aiState = AIState.death;
    }


    IEnumerator Think(){
    	while(true){
            //If a player exists, check whether they are within range for attacking
            if(target != null){
                float playerDistance = Vector3.Distance(target.position,transform.position);
                float brainDistance = Vector3.Distance(brain.position,transform.position);          

                switch (aiState) {
                    case AIState.target_brain:
                        //Target the brain first!
                        nm.SetDestination(brain.position);
                        charAnim.SetTrigger("Running");
                        //Check if the brain is within attacking distance, if it is, attack
                        if (brainDistance < attackDistance) aiState = AIState.attacking_brain;
                        //Check if player is closer than the brain, if the player is, target the player
                        if(playerDistance < brainDistance) aiState = AIState.target_player;
                        break;
                    case AIState.target_player:
                        //Target the player first
                        nm.SetDestination(target.position);
                        charAnim.SetTrigger("Running");
                        //Check if the player is within attacking distance, if it is, attack
                        if(playerDistance < attackDistance) aiState = AIState.attacking_player;
                        //Check if the brain is closer, if so, target it instead
                        if(brainDistance < playerDistance) aiState = AIState.target_brain;
                        break;
                    case AIState.attacking_brain:
                        //Attack the brain!
                        brain.SendMessage("dealDamage",attackDamage);
                        charAnim.SetTrigger("Attacking");
                        break;
                    case AIState.attacking_player:
                        //Attack the player
                        target.SendMessage("dealDamage",attackDamage);
                        charAnim.SetTrigger("Attacking");
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, Time.deltaTime * 1);
                        //If the player is out of attack range, chase the player
                        if(playerDistance > attackDistance) aiState = AIState.target_player;
                        //If the player somehow escapes quickly, forget the player and go for the brain
                        if(playerDistance > viewDistance) aiState = AIState.target_brain;
                        break;
                    case AIState.death:
                        this.GetComponent<Collider>().enabled = !this.GetComponent<Collider>().enabled;
                        charAnim.SetTrigger("Falling");
                        for (int i = 0; i < 3; i++) gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        nm.SetDestination(transform.position);
                        if(!isDead){
                            _uiManager.SendMessage("updateKillCount");
                            isDead = true;
                        }
                        Destroy(gameObject,3F);
                        break;
                }
            }
            //Otherwise target the brain immediately
            yield return new WaitForSeconds(0.1F);
        }

        	
        
    }

}
