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
    private bool myUnlocked;

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

        myDamageModifier = 1;
        myAttackEnergyModifier = 1;
    }

    public sword_class(int id, string name, float damage, float energy, int size, bool unlocked)
    {
        myID = id;
        myName = name;
        myDamage = damage;
        myAttackEnergy = energy;
        mySize = size;       
        myUnlocked = unlocked;

        //always 1 at start
        myDamageModifier = 1;
        myAttackEnergyModifier = 1;
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

    public bool getUnlocked()
    {
        return myUnlocked;
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
        return myDamage * myDamageModifier;
    }

    public float getAttackEnergyWithModifier()
    {
        return myAttackEnergy * myAttackEnergyModifier;
    }

}

