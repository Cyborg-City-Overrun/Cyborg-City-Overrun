using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    private Saver saver = new Saver();
    //Function to load the game
   public void PlayGame()
    {
        for(int i = 0; i < saver.getPotionSaveNames().Length; i++ )
        {
            PlayerPrefs.SetInt(saver.getPotionSaveNames()[i], 0);
        }

        for (int i = 0; i < saver.getMaterialSaveNames().Length; i++)
        {
            PlayerPrefs.SetInt(saver.getMaterialSaveNames()[i], 0);
        }

        SceneManager.LoadScene(1);
    }

    //Function to Quit the Game
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
