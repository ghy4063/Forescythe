using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //quit button that when pressed exits the application
    public void quitButton()
    {
        Application.Quit();

    }
    //loads the options menu when pressed
    public void optionButton()
    {
        SceneManager.LoadScene("OptionMenu");

    }
    //Begins the game when pressed
    public void startGame()
    {
        SceneManager.LoadScene("GraveyardTest");
        Time.timeScale = 1.0f;
    }
    //loads the main menu when pressed
    public void MainMenuButton()
    {

        SceneManager.LoadScene("MainMenu");
    }
}
