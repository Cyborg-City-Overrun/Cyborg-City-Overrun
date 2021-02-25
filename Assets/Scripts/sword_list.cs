using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_list : MonoBehaviour
{
    //define each sword here: (int id, string name, float damage, float attackEnergy, 
                                //int size, int price, bool unlocked) size is 0, 1, or 2
    private sword_class starterSword = new sword_class(0, "Starter Sword", 4f, 10f, 1, true);
    private sword_class greatSword = new sword_class(1, "Great Sword", 12f, 20f, 2, false);
    private sword_class dagger = new sword_class(2, "dagger", 3f, 4f, 0, false);

    private sword_class[] swords = new sword_class[3]; //Change this to be equal to the number of swords

    private void Start()
    {
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

}
