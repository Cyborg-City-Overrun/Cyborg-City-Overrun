using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Canvas PauseMenu;
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void HideMe()
    {
        PauseMenu.gameObject.SetActive(false);
    }
}
