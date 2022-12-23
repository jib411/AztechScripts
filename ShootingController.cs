using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShootingController : NetworkBehaviour
{
    public int damage = 25;
    private GameObject character;
    private RaycastHit hitInfo;
    private AudioSource gunShot;

    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;
        gunShot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            gunShot.Play();
            /*Vector3 directionOfFire = character.transform.forward;

            if (Physics.Raycast (transform.position, directionOfFire, out hitInfo, 20))
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.yellow);

                drawLine((transform.position + hitInfo.point) / 2, hitInfo.point, Color.blue);
                
                hitInfo.transform.SendMessage("HitByBullet", damage, SendMessageOptions.DontRequireReceiver);
            }*/
        }
    }
    /*
    void drawLine(Vector3 start, Vector3 end, Color color, float duration = 0.02f)
    {
        Debug.Log("Draw line");

        GameObject myline = new GameObject();
        myline.transform.position = start;
        myline.AddComponent<LineRenderer>();
        LineRenderer lr = myline.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Standard"));

        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myline, duration);
    }*/
}
