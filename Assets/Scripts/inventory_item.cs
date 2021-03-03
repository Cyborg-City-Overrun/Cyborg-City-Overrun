using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inventory_item : MonoBehaviour
{
    public Sprite displayImage;
    public string displayName;
    public int displayNumber = 0;

    public Button customButton;

    private void Update()
    {
        if (this.gameObject.tag == "Potion")
        {
            displayNumber = this.gameObject.GetComponent<potions>().getMyNumberInInventory();
        }
    }
}
