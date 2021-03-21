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

    //upgrades
    private upgrade_class myUpgradeDamage;
    private upgrade_class myUpgradeEnergy;
    private upgrade_class myUpgradeCrit;
    private upgrade_class[] upgrades;

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
        myCritChance = 0f;
        myCritDamage = 2.5f;

        myUpgradeDamage = null;
        myUpgradeEnergy = null;
        myUpgradeCrit = null;
    }

    public sword_class(int id, string name, float damage, float energy, int size, bool unlocked, int price, upgrade_class upgradeDamage, upgrade_class upgradeEnergy, upgrade_class upgradeCrit)
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
        myCritChance = 0f;
        myCritDamage = 3f;

        myUpgradeDamage = upgradeDamage;
        myUpgradeEnergy = upgradeEnergy;
        myUpgradeCrit = upgradeCrit;

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
    public float GetBaseDamageWithModifier()
    {
        return (GetDamage() + GetUpgradeModifierTotalDamage());
    }

    public float GetDamageWithModifier()
    {
        return (GetDamage() + GetUpgradeModifierTotalDamage() + GetVariance()) * GetCrit() /* * damage from tree*/;
    }

    private float GetVariance()
    {
        myVariance = (GetDamage() + GetUpgradeModifierTotalDamage()) / 4;
        return Random.Range(-myVariance, myVariance + 1);
    }

    private float GetCrit()
    {
        if (Random.Range(0, 100) < myCritChance + GetUpgradeModifierTotalCrit())
        {
            return myCritDamage;
        }
        else
        {
            return 1;
        }
    }

    public float GetAttackEnergyWithModifier()
    {
        return myAttackEnergy + GetUpgradeModifierTotalEnergy(); //plus because the modifier is a negative value
    }


    //damage upgrades
    public void UpgradeDamage()
    {
        myUpgradeDamage.Upgrade();
    }
    public float GetUpgradeModifierNextDamage()
    {
        return myUpgradeDamage.GetModifierNext();
    }

    public float GetUpgradeModifierTotalDamage()
    {
        return myUpgradeDamage.GetModifierTotal();
    }

    public int GetUpgradeCountDamage()
    {
        return myUpgradeDamage.GetCurrentUpgradeCount();
    }

    public int GetUpgradePriceDamage()
    {
        return myUpgradeDamage.GetPrice();
    }

    public bool CanUpgradeDamage()
    {
        return myUpgradeDamage.CanUpgrade();
    }


    //energy upgrades
    public void UpgradeEnergy()
    {
        myUpgradeEnergy.Upgrade();
    }
    public float GetUpgradeModifierNextEnergy()
    {
        return myUpgradeEnergy.GetModifierNext();
    }

    public float GetUpgradeModifierTotalEnergy()
    {
        return myUpgradeEnergy.GetModifierTotal();
    }

    public int GetUpgradeCountEnergy()
    {
        return myUpgradeEnergy.GetCurrentUpgradeCount();
    }

    public int GetUpgradePriceEnergy()
    {
        return myUpgradeEnergy.GetPrice();
    }

    public bool CanUpgradeEnergy()
    {
        return myUpgradeEnergy.CanUpgrade();
    }


    //Crit upgrades
    public void UpgradeCrit()
    {
        myUpgradeCrit.Upgrade();
    }
    public float GetUpgradeModifierNextCrit()
    {
        return myUpgradeCrit.GetModifierNext();
    }

    public float GetUpgradeModifierTotalCrit()
    {
        return myUpgradeCrit.GetModifierTotal();
    }

    public int GetUpgradeCountCrit()
    {
        return myUpgradeCrit.GetCurrentUpgradeCount();
    }

    public int GetUpgradePriceCrit()
    {
        return myUpgradeCrit.GetPrice();
    }

    public bool CanUpgradeCrit()
    {
        return myUpgradeCrit.CanUpgrade();
    }

    public upgrade_class GetDamageUpgrade()
    {
        return myUpgradeDamage;
    }

    public upgrade_class getEnergyUpgrade()
    {
        return myUpgradeEnergy;
    }

    public upgrade_class getCritUpgrade()
    {
        return myUpgradeCrit;
    }

    public upgrade_class[] getAllUpgrades()
    {
        upgrades = new upgrade_class[3];
        upgrades[0] = myUpgradeDamage;
        upgrades[1] = myUpgradeEnergy;
        upgrades[2] = myUpgradeCrit;
        return upgrades;
    }
}

