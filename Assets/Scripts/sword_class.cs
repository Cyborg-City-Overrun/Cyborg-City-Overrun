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
    private string[] swordSaveNames = { "StarterSword", "GreatSword", "Dagger" };

    private upgrade_class myUpgradeDamage;


    public sword_class() //default constructor should not be used
    {
        myID = -1;
        myName = "Default";
        myDamage = 1;
        myAttackEnergy = 1;
        mySize = 1;
        myUnlocked = true;
        myPrice = 0;

        myVariance = myDamage / 4;
        myCritChance = 1;
        myCritDamage = 2;

        myUpgradeDamage = null;
    }

    public sword_class(int id, string name, float damage, float energy, int size, bool unlocked, int price, upgrade_class upgrades)
    {
        myID = id;
        myName = name;
        myDamage = damage;
        myAttackEnergy = energy;
        mySize = size;       
        myUnlocked = unlocked;
        myPrice = price;

        //always same at start

        myVariance = myDamage / 4;
        myCritChance = 1;
        myCritDamage = 2;

        myUpgradeDamage = upgrades;

    }


    public int GetID()
    {
        return myID;
    }

    public string GetName()
    {
        return myName;
    }

    public float GetDamage()
    {
        return myDamage;
    }

    public float GetAttackEnergy()
    {
        return myAttackEnergy;
    }

    public int GetSize()
    {
        return mySize;
    }

    public void GetUnlocked(bool isLocked)
    {
        myUnlocked = isLocked;
    }

    public bool GetUnlocked()
    {
        if (PlayerPrefs.GetInt(swordSaveNames[myID]) == 1)
        {
            return true;
        }
        else return false;
    }

    public int GetPrice()
    {
        return myPrice;
    }

    public float GetDamageWithModifier()
    {
        return (GetDamage() + GetUpgradeModifierDamage() + GetVariance()) * GetCrit();
    }

    private float GetVariance()
    {
        myVariance = (GetDamage() + GetUpgradeModifierDamage()) / 4;
        return Random.Range(-myVariance, myVariance + 1);
    }

    private float GetCrit()
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

   
    //damage upgrades
    public void UpgradeDamage()
    {
        myUpgradeDamage.Upgrade();
    }

    public float GetUpgradeModifierDamage()
    {
        return myUpgradeDamage.GetModifierTotal();
    }

    public int GetUpgradePriceDamage()
    {
        return myUpgradeDamage.GetPrice();
    }

    public bool CanUpgradeDamage()
    {
        return myUpgradeDamage.CanUpgrade();
    }
}

