using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class inventory_item : MonoBehaviour
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

    public void buttonActionInventory()
    {
        switch (this.gameObject.tag)
        {
            case "Potion":
                this.gameObject.GetComponent<potions>().ConsumePotion();
                break;
            case "Weapon":
                myPlayer.GetComponent<player_control>().SetWeapon(displayNumber);
                break;
            case "Material":
                //no button action
                break;
        }
    }

    public void buttonActionShop()
    {
        switch (this.gameObject.tag)
        {
            case "Potion":
                this.gameObject.GetComponent<potions>().BuyPotion(displayNumber);
                break;
        }
    }
}
