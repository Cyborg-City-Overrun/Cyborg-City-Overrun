using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_list : MonoBehaviour
{
    private upgrade_class starterUpgradeDamage;
    private upgrade_class starterUpgradeEnergy;
    private upgrade_class starterUpgradeCrit;
    private sword_class starterSword;

    private upgrade_class greatSwordUpgradeDamage;
    private upgrade_class greatSwordUpgradeEnergy;
    private upgrade_class greatSwordUpgradeCrit;
    private sword_class greatSword;

    private upgrade_class daggerUpgradeDamage;
    private upgrade_class daggerUpgradeEnergy;
    private upgrade_class daggerUpgradeCrit;
    private sword_class dagger;
    
    private string[] swordSaveNames = { "StarterSword", "GreatSword", "Dagger" };

    private sword_class[] swords;



    private void Start()
    {
        //define each swords upgrades (float[], price[])
        //make sure the arrays are same length

        //define each sword (int id, string name, float damage, float attackEnergy, 
        //int size, int price, bool unlocked) size is 0, 1, or 2

        //starter sword
        starterUpgradeDamage = new upgrade_class(new float[] { 1, 2, 3 }, new int[] { 10, 20, 30 });
        starterUpgradeEnergy = new upgrade_class(new float[] { -1, -2 }, new int[] { 30, 50 });
        starterUpgradeCrit = new upgrade_class(new float[] { 1, 2, 3 }, new int[] { 30, 50, 70 });

        starterSword = new sword_class(0, "Starter Sword", 4f, 10f, 1, true, 0, starterUpgradeDamage, starterUpgradeEnergy, starterUpgradeCrit);

        //great sword
        greatSwordUpgradeDamage = new upgrade_class(new float[] { 3, 4, 5 }, new int[] { 50, 70, 90 });
        greatSwordUpgradeEnergy = new upgrade_class(new float[] { -3, -3, -3 }, new int[] { 60, 80, 100 });
        greatSwordUpgradeCrit = new upgrade_class(new float[] { 2, 4, 6 }, new int[] { 50, 100, 150 });

        greatSword = new sword_class(1, "Great Sword", 12f, 20f, 2, false, 300, greatSwordUpgradeDamage, greatSwordUpgradeEnergy, greatSwordUpgradeCrit);

        //dagger
        daggerUpgradeDamage = new upgrade_class(new float[] { 1, 1, 1, 2, 2, 2 }, new int[] { 30, 30, 30, 40, 40, 40 });
        daggerUpgradeEnergy = new upgrade_class(new float[] { -1, -1 }, new int[] { 40, 60 });
        daggerUpgradeCrit = new upgrade_class(new float[] { 3, 3, 3, 3 }, new int[] { 60, 100, 140, 180 });

        dagger = new sword_class(2, "Dagger", 3f, 6f, 0, false, 200, daggerUpgradeDamage, daggerUpgradeEnergy, daggerUpgradeCrit);



        //swords array
        swords = new sword_class[3]; //Change this to be equal to the number of swords


        swords[0] = starterSword;
        swords[1] = greatSword;
        swords[2] = dagger;
    }


    public sword_class getSword(int id)
    {
        return swords[id];
    }

    public int getNumSwords()
    {
        return swords.Length;
    }

    public void unlockWeapon(int id)
    {
        if (swords[id].GetUnlocked() == false)
        {
            swords[id].GetUnlocked(true);
            PlayerPrefs.SetInt(swordSaveNames[id], 1);
            print("Sword Unlocked");
        }
        else
        {
            print("Sword was already unlocked");
        }
    }
}
