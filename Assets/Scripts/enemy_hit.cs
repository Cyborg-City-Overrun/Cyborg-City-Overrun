using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hit : MonoBehaviour
{
    private float myHealth = 20f;
    private SpriteRenderer render;
    private float colorTimer = 0;


    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Attack")
        {
            myHealth -= 5;
            render.color = new Color(1, render.color.b-.25f, render.color.g-.25f);
            print(myHealth);
            if (myHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
