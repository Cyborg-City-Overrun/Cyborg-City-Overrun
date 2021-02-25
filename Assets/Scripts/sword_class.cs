using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_class
{
    private int myID;
    private string myName;
    private float myDamage;
    private float myAttackEnergy;
    private int mySize; //0, 1, 2 = small, med, large
    private int myPrice;
    private bool myUnlocked;

    public sword_class()
    {
        myID = -1;
        myName = "Default";
        myDamage = 1;
        myAttackEnergy = 1;
        mySize = 1;
        myPrice = 0;
        myUnlocked = true;
    }

    public sword_class(int id, string name, float damage, float energy, int size, int price, bool unlocked)
    {
        myID = id;
        myName = name;
        myDamage = damage;
        myAttackEnergy = energy;
        if (size >= 0 && size <= 2)
        {
            mySize = size;
        }
        else
        {
            mySize = 1;
        }
        myPrice = price;
        myUnlocked = unlocked;
    }


    public int getID()
    {
        return myID;
    }

    public string getName()
    {
        return myName;
    }

    public float getDamage()
    {
        return myDamage;
    }

    public float getAttackEnergy()
    {
        return myAttackEnergy;
    }

    public int getSize()
    {
        return mySize;
    }

    public int getPrice()
    {
        return myPrice;
    }

    public bool getUnlocked()
    {
        return myUnlocked;
    }
}
