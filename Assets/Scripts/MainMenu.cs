using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    private Saver saver = new Saver();
    //Function to load the game
   public void PlayGame()
    {
        saver.newGame();
        SceneManager.LoadScene(1);
    }

    //Function to Quit the Game
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
