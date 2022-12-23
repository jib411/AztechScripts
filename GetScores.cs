using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetScores : MonoBehaviour
{
	public Text _scoreText;
    public Text _timerText;

    void Awake(){
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene aScene, LoadSceneMode aMode){
        if(aScene.name == "GameOver" && this != null) {
            //Get scores
            _scoreText.text = "Time survived: " + UIManager.seconds;
            _timerText.text = "Kill count: " + UIManager.kills;
        }
    }
}
