using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    private Saver saver = new Saver();
    //Function to load the game
   public void NewGame()
    {
        saver.newGame();
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        //load game
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        //open the controls menu
        print("This tab isnt set up yet");
    }

    public void Options()
    {
        //open the options menu
        print("This tab isnt set up yet");
    }
    public void Creadits()
    {
        //open the credits menu
        print("This tab isnt set up yet");
    }

    //Function to Quit the Game
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
