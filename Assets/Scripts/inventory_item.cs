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
        if (this.gameObject.tag == "Potion")
        {
            displayNumber = this.gameObject.GetComponent<potions>().getMyNumberInInventory();
        }
    }

    public void buttonAction()
    {
        switch (this.gameObject.tag)
        {
            case "Potion":
                this.gameObject.GetComponent<potions>().ConsumePotion();
                break;
            case "Weapon":
                myPlayer.GetComponent<player_control>().SetWeapon(displayNumber);
                break;
        }
    }
}
