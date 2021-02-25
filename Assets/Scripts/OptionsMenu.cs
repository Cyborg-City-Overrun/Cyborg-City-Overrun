using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Canvas PauseMenu;

    //Function to bring to Main menu
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    
    //Function to hide the Pause Menu
    public void HideMe()
    {
        PauseMenu.gameObject.SetActive(false);
    }
}
