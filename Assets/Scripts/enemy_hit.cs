using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hit : MonoBehaviour
{
    private float myHealth = 20f;

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Attack")
        {
            myHealth -= 5;
            print(myHealth);
            if (myHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
