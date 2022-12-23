using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
	public int damage = 25;
    void OnCollisionEnter(Collision coll){
    	if(coll.gameObject.tag == "Enemy"){
    		coll.gameObject.SendMessage("HitByBullet", damage, SendMessageOptions.DontRequireReceiver);
    		Destroy(gameObject);
    	}
    	Destroy(gameObject, 1);
    }
}
