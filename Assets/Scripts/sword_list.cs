using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_list : MonoBehaviour
{
    //define each sword here: (int id, string name, float damage, float attackEnergy, int size) size is 0, 1, or 2
    private sword_class starterSword = new sword_class(0, "Starter Sword", 4f, 4f, 1);
    private sword_class secondSword = new sword_class(1, "2.0", 5f, 3f, 1);

    private sword_class[] swords = new sword_class[2]; //Change this to be equal to the number of swords

    private void Start()
    {
        swords[0] = starterSword;
        swords[1] = secondSword;
    }


    public sword_class getSword(int id)
    {
        return swords[id];
    }

    public int getNumSwords()
    {
        return 2; //update this to be equal to the number of swords
    }

}
