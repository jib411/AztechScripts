using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject OptionsMenu;
    [SerializeField] private Slider volumeSlider = null;

    private void Start()
    {
        LoadValues();
    }

    public void startGame(){
    	print("startGame()");
    	SceneManager.LoadScene(1); 
    }

    public void optionsMenu()
    {
        print("optionsMenu()");
        Menu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void quitGame(){
    	print("quitGame()");
    	Application.Quit();
    }

    public void backToMenu()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();


        print("backToMenu()");
        OptionsMenu.SetActive(false);
        Menu.SetActive(true);
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
