using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour{
    [SerializeField] private float health = 120;
    private UIManager _uiManager;
    public Transform[] m_SpawnPoints;
    public float respawnCoolDown = 1F;
    public bool despawned = false;
    [SerializeField] private Sprite[] _bloodBorders;

    // Start is called before the first frame update
    void Start(){
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.Log("The UIManager is NULL.");
        }

        _uiManager.UpdateSoldierHealth(health);
        _uiManager.UpdateBorders(health);
    }

    // Update is called once per frame
    void Update(){  
    }

    public void GainedHealthKit()
    {
        health += 12;

        if(health >= 109)
        {
            health = 120;
        }

        _uiManager.UpdateBorders(health);
        _uiManager.UpdateSoldierHealth(health);
    }
    IEnumerator dealDamage(float damage){
        //Decrement health and update player HUD
        health = health - damage;
        _uiManager.UpdateSoldierHealth(health);
        _uiManager.UpdateBorders(health);
        //If player dies and they aren't already despawned then disable the player's camera and 
        //move them far away from the zombies to simulate being dead
        if(health <= 0 && !despawned){
            despawned = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled = false;
            GameObject.FindGameObjectWithTag("BrainCam").GetComponent<Camera>().enabled = true;
            transform.position = new Vector3(10000,10000,10000);
            //Wait for the respawn cooldown
            yield return new WaitForSeconds(respawnCoolDown);
            //Respawn the player with 50 health at a random location
            health = 50;
            _uiManager.UpdateSoldierHealth(health);
            respawnCoolDown *= 2;
            GameObject.FindGameObjectWithTag("BrainCam").GetComponent<Camera>().enabled = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled = true;
            transform.position = m_SpawnPoints[Mathf.RoundToInt(Random.Range(0f,m_SpawnPoints.Length-1))].transform.position;
            despawned = false;
        }
        else yield return null;
        
    }
}
