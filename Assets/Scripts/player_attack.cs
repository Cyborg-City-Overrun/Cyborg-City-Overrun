using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    private GameObject myTarget;

    private void Start()
    {
        myTarget = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            hit.GetComponent<enemy_control>().TakeDamage(myTarget.GetComponent<player_control>().getDamage());
        }
    }
}
