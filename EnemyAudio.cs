using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource attackAudio;
    public AudioSource brainAudio;
    private float audioQueueTime = 0.0f;
    public float attackGap = 3.0f;
    public float brainGap = 5.0f;

    private Transform target;
    private Transform brain;
    //[SerializeField] private float attackDistance = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        brain = GameObject.FindGameObjectWithTag("Brain").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = Vector3.Distance(target.position, transform.position);
        float brainDistance = Vector3.Distance(brain.position, transform.position);

        if (playerDistance < brainDistance)
        {
            if (Time.time > audioQueueTime)
            {
                audioQueueTime = Time.time + attackGap;

                attackAudio.Play();
            }
        }
        else
        if (Time.time > audioQueueTime)
        {
            audioQueueTime = Time.time + brainGap;

            brainAudio.Play();
        }
    }
}
