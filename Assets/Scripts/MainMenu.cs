using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    //Function to load the game
   public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    //Function to Quit the Game
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
