using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public Canvas TheBetterShop;

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Interact")
        {
            print("hello");
            TheBetterShop.gameObject.SetActive(true);
        }
    }
    public void HideMe()
    {
        TheBetterShop.gameObject.SetActive(false);
    }
}
