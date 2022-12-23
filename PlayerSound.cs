using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private bool isMoving;
    public AudioSource walkAudio;
    public GameHUD _pauseMenu;

    void Update()
    {
        walk();
    }
    void walk()
    {

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) isMoving = true;
        else isMoving = false;
        if (!walkAudio.isPlaying && isMoving && !_pauseMenu.GamePaused) walkAudio.Play();
        else if(!isMoving) walkAudio.Stop();
    }
}
