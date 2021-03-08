using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private Saver saver = new Saver();

    private GameObject myPlayer;

    private void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");

    }

    //Function to restart when player dies
    public void Restart()
    {
        myPlayer.GetComponent<player_control>().RestoreHealth(1000000);
        //saver.saveGame();
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
