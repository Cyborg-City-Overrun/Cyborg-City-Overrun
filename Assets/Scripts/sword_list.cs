using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_list : MonoBehaviour
{
    private upgrade_class starterUpgradeDamage;
    private sword_class starterSword;

    private upgrade_class greatSwordUpgradeDamage;
    private sword_class greatSword;

    private upgrade_class daggerUpgradeDamage;
    private sword_class dagger;
    
    private string[] swordSaveNames = { "StarterSword", "GreatSword", "Dagger" };

    private sword_class[] swords;



    private void Start()
    {
        //define each swords upgrades (float[] damage)


        //define each sword (int id, string name, float damage, float attackEnergy, 
        //int size, int price, bool unlocked) size is 0, 1, or 2

        starterUpgradeDamage = new upgrade_class(new float[] { 1, 2, 3 }, new int[] { 10, 20, 30 });
        starterSword = new sword_class(0, "Starter Sword", 4f, 10f, 1, true, 0, starterUpgradeDamage);

        greatSwordUpgradeDamage = new upgrade_class(new float[] { 3, 4, 5 }, new int[] { 30, 40, 50 });
        greatSword = new sword_class(1, "Great Sword", 12f, 20f, 2, false, 300, greatSwordUpgradeDamage);

        daggerUpgradeDamage = new upgrade_class(new float[] { 2, 2, 2, 2, 2 }, new int[] { 20, 20, 20, 20, 20 });
        dagger = new sword_class(2, "Dagger", 3f, 4f, 0, false, 200, daggerUpgradeDamage);


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
