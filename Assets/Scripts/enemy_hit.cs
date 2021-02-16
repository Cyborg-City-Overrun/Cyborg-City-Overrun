using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hit : MonoBehaviour
{
    private float myMaxHealth = 20f;
    private float myHealth;
    //private SpriteRenderer render;
    //private float colorTimer = 0;

    public HealthBar myHealthBar;


    private void Start()
    {
        //render = GetComponent<SpriteRenderer>();
        myHealthBar.SetMaxHealth(myMaxHealth);
        myHealth = myMaxHealth;
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Attack")
        {
            takeDamage(4);
            
            if (myHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void takeDamage(float damage)
    {
        myHealth -= damage;

        //render.color = new Color(1, render.color.b - .25f, render.color.g - .25f);

        myHealthBar.SetHealth(myHealth);
    }
}
