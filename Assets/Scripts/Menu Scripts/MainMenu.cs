using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    private Saver saver = new Saver();

    public Canvas ControlsMenu;
    public Canvas CreditsMenu;
    public Canvas MainMenuCanvas;
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
        MainMenuCanvas.gameObject.SetActive(false);
        ControlsMenu.gameObject.SetActive(true);
    }

    public void Options()
    {
        //open the options menu
        print("This tab isnt set up yet");
    }
    public void Creadits()
    {
        //open the credits menu
        MainMenuCanvas.gameObject.SetActive(false);
        CreditsMenu.gameObject.SetActive(true);
    }

    //Function to Quit the Game
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
