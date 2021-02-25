using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    //Function to bring to main menu after death
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
