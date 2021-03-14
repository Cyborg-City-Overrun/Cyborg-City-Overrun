using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shop_items : MonoBehaviour
{
    public Sprite displayImage;
    public string displayName;
    public int displayNumber;
    private GameObject myPlayer;

    private void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        switch (this.gameObject.tag)
        {
            case "Potion":
                displayNumber = this.gameObject.GetComponent<potions>().getMyNumberInInventory();
                break;
            case "Weapon":
                break;
            case "Material":
                displayNumber = this.gameObject.GetComponent<number_in_inventory>().getNum();
                break;
        }

        if (this.gameObject.tag == "Potion")
        {
            
        }
    }

    public void buttonAction()
    {
        switch (this.gameObject.tag)
        {
            case "Potion":
                //this.gameObject.GetComponent<shop>().buyPotion();
                break;
            case "Weapon":
                break;
            case "Material":
                //no button action
                break;
        }
    }
}
