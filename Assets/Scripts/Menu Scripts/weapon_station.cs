using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_station : MonoBehaviour
{
    private GameObject myPlayer;

    public Canvas menu;


    public void Start()
    {
        gameObject.SetActive(true);
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Interact")
        {
            print("weapon station");
            menu.gameObject.SetActive(true);
        }
    }
    public void HideMe()
    {
        menu.gameObject.SetActive(false);
    }
}
