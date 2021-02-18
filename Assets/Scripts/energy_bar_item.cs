using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy_bar_item : item
{
    

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            hit.GetComponent<player_control>().RestoreEnergy(this.restoreAmount);
            Destroy(gameObject);
        }
    }
}
