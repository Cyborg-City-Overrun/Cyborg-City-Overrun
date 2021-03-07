using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_class
{
    //constructor variables
    private int myID;
    private string myName;
    private float myDamage;
    private float myAttackEnergy;
    private int mySize; //0, 1, 2 = small, med, large
    private float myVariance;
    private float myCritChance;
    private float myCritDamage;
    private bool myUnlocked;
    private int myPrice;

    //other variables
    private float myDamageModifier;
    private float myAttackEnergyModifier;


    public sword_class() //default constructor, only uesd at start.
    {
        myID = -1;
        myName = "Default";
        myDamage = 1;
        myAttackEnergy = 1;
        mySize = 1;
        myUnlocked = true;
        myPrice = 0;

        myDamageModifier = 1;
        myAttackEnergyModifier = 1;
        myCritDamage = 2;
    }

    public sword_class(int id, string name, float damage, float energy, int size, bool unlocked, int price)
    {
        myID = id;
        myName = name;
        myDamage = damage;
        myAttackEnergy = energy;
        mySize = size;       
        myUnlocked = unlocked;
        myPrice = price;

        //always same at start
        myDamageModifier = 1;
        myAttackEnergyModifier = 1;
        myVariance = myDamage / 4;
        myCritChance = 1;
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

    public void setUnlocked(bool isLocked)
    {
        myUnlocked = isLocked;
    }

    public bool getUnlocked()
    {
        return myUnlocked;
    }

    public int getPrice()
    {
        return myPrice;
    }

    public void setDamageModifier(float modifier)
    {
        myDamageModifier = modifier;
    }

    public float getDamageModifier()
    {
        return myDamageModifier;
    }

    public void setAttackEnergyModifier(float modifier)
    {
        myAttackEnergyModifier = modifier;
    }
    public float getAttackEnergyModifier()
    {
        return myAttackEnergyModifier;
    }

    public float getDamageWithModifier()
    {
        return (getDamage() + getVariance()) * getDamageModifier() * getCrit();
    }

    public float getAttackEnergyWithModifier()
    {
        return myAttackEnergy * myAttackEnergyModifier;
    }

    private float getVariance()
    {
        return Random.Range(-myVariance, myVariance + 1);
    }

    private float getCrit()
    {
        if (Random.Range(0, 100) < myCritChance)
        {
            return myCritDamage;
        }
        else
        {
            return 1;
        }
    }

}

