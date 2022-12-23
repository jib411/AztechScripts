using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
	Animator charAnim;
    private bool walkState = false;
    // Start is called before the first frame update
    void Start()
    {
        charAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float mvY = Input.GetAxis("Horizontal");
        float mvX = Input.GetAxis("Vertical");

        if (mvX != 0 || mvY != 0)
        {
            if (walkState == false)
            {
                charAnim.SetTrigger("Run");
                walkState = true;
            }
        }
        else
        {
            if (walkState == true)
            {
                charAnim.SetTrigger("Idle");
                walkState = false;
            }
        }
    }
}
