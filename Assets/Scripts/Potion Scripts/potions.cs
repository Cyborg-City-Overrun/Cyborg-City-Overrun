using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potions : MonoBehaviour
{
    public int myID;

    private int myNumberInInventory;
    public string saveName;
    
    public float effectAmount;
    public int price;
    public int vendPrice = 60;

    private float myTimer = 0;
    public float modifierDurration;

    private bool myActive = false;

    public GameObject player;

    private void Start()
    {
        myNumberInInventory = PlayerPrefs.GetInt(saveName);
    }
    private void FixedUpdate()
    {
        myTimer -= Time.fixedDeltaTime;
        if (myTimer <= 0 && myActive == true)
        {
            player.GetComponent<player_control>().setAttackModifierPotion(1);
            print("potion effect over");
            myActive = false;
        }
    }

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
                player.GetComponent<player_control>().RestoreHealth(effectAmount); //health potion
                break;
            case 1:
                player.GetComponent<player_control>().RestoreEnergy(effectAmount); //energy potion
                break;
            case 2:
                player.GetComponent<player_control>().setAttackModifierPotion(effectAmount); //attack buff potion
                myTimer = modifierDurration;
                myActive = true;
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

    public int getVendPrice()
    {
        return vendPrice;
    }

    public void setID(int id)
    {
        myID = id;
    }

    public int getMyNumberInInventory()
    {
        return myNumberInInventory;
    }

    public void setMyNumberInInventory(int newNum)
    {
        this.myNumberInInventory = newNum;
    }

    public int getTimer()
    {
        return (int)(myTimer+1);
    }

    public void BuyPotion(int id)
    {
        if (player.GetComponent<player_control>().Transaction(-price))
        {
            addPotion(1);
        }
    }

    public void VendPotion(int id)
    {
        addPotion(1);
    }
}
