using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Save()
    {
       
    }

    public void Load()
    {
        
    }

    public void Back()
    {
        SceneManager.LoadScene(1);
    }
}
