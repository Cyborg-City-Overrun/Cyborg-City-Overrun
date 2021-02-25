using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potions : MonoBehaviour
{
    public int myID;

    private int myNumberInInventory = 0;
    
    public float effectAmount;
    public int price;

    public GameObject player;


    public void ConsumePotion()
    {   
        if (myNumberInInventory > 0)
        {
            PotionEffect();
            myNumberInInventory--;
            print("consumed potion: " + myNumberInInventory + " left");
        }
        else
        {
            print("You do not have any potions");
        }
    }

    private void PotionEffect()
    {
        switch (myID)
        {
            case 0:
                player.GetComponent<player_control>().RestoreHealth(effectAmount);
                break;
            case 1:
                player.GetComponent<player_control>().RestoreEnergy(effectAmount);
                break;
        }

        
    }

    public void addPotion(int num)
    {
        myNumberInInventory += num;
        print("potion added. you now have " + myNumberInInventory);
    }

    public int getNumberOfPotions()
    {
        return myNumberInInventory;
    }

    public int getPrice()
    {
        return price;
    }
}
