using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
	public Rigidbody bullet;
	private Rigidbody bullet_clone;
	public float magnitude = 10F;
    public GameHUD _pauseMenu;

    void Update(){
        if (_pauseMenu.GamePaused)
        {

        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                bullet_clone = Instantiate(bullet, transform.position, transform.rotation);
                bullet_clone.AddForce(transform.forward * magnitude, ForceMode.Impulse);
            }
    	}
    }
}
