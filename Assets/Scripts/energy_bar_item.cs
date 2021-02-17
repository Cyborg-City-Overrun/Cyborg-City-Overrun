using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy_bar_item : MonoBehaviour
{
    public float restoreAmount;

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            hit.GetComponent<player_control>().RestoreEnergy(restoreAmount);
            Destroy(gameObject);
        }
    }
}
