using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public Canvas ShopMenu;

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Interact")
        {
            print("hello");
            ShopMenu.gameObject.SetActive(true);
        }
    }
}
