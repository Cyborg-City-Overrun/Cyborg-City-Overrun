using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    private GameObject myPlayer;

    public Canvas menu;


    public void Start()
    {
        gameObject.SetActive(true);
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        CheckPlayerDistance();
    }

    private void CheckPlayerDistance()
    {
        if (Vector2.Distance(gameObject.transform.position, myPlayer.GetComponent<Transform>().position) > 1)
        {
            print("Too far. Leaving shop.");
            menu.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Interact")
        {
            print("hello");
            menu.gameObject.SetActive(true);
        }
    }
    public void HideMe()
    {
        menu.gameObject.SetActive(false);
    }
    public void HealthPotion()
    {
        print("Health Potion: 20");

        if (myPlayer.GetComponent<player_control>().Transaction(-20))
        {
            myPlayer.GetComponent<player_control>().RestoreHealth(25);
        }
    }

}
