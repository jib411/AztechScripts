using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    float moveForward;
    float moveSide;
    float moveUp;

    bool isGrounded;

    public GameHUD _pauseMenu;
    public float walkSpeed = 1f;
    public float sprintSpeed = 2f;
    private float moveSpeed;
    public float jumpPower = 5f;
    Rigidbody player;
    private AudioSource gunAudio;
    
    void Start(){
        gunAudio = GetComponent<AudioSource>();
        player = GetComponent<Rigidbody>();
        moveSpeed = walkSpeed;
    }

    void Update(){
        if (Input.GetButtonDown("Fire1") && !_pauseMenu.GamePaused) gunAudio.Play();
        if(Input.GetKey(KeyCode.LeftShift)) moveSpeed = sprintSpeed;
        else moveSpeed = walkSpeed;
        moveForward = Input.GetAxisRaw("Vertical") * moveSpeed;
        moveSide = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveUp = Input.GetAxisRaw("Jump") * jumpPower;
    }
    private void FixedUpdate(){
        player.velocity = (transform.forward * moveForward) + (transform.right * moveSide) + (transform.up * player.velocity.y);
        if(isGrounded && moveUp != 0){
            player.AddForce(transform.up * moveUp, ForceMode.VelocityChange);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision coll){
        isGrounded = true;
    }
}
