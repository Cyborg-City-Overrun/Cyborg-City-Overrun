using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class inventory_item : MonoBehaviour
{
    public Sprite displayImage;
    public string displayName;
    public int displayNumber = 0;

    private void Update()
    {
        if (this.gameObject.tag == "Potion")
        {
            displayNumber = this.gameObject.GetComponent<potions>().getMyNumberInInventory();
        }
    }

    public void buttonAction()
    {
        print(displayName);
    }
}
