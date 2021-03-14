using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Canvas PauseMenu;
    public Canvas ControlsMenu;
    //Function to load the game
    //Function to bring to Main menu
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    //Function to hide the Pause Menu
    public void HideMe()
    {
        PauseMenu.gameObject.SetActive(false);
    }

    public void LoadGame()
    {
        //load game
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        //open the controls menu
        ControlsMenu.gameObject.SetActive(true);
    }

    public void Options()
    {
        //open the options menu
        print("This tab isnt set up yet");
    }

}
