using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrade_class
{
    private float[] myModifier;
    private int myModifierCount;

    private int[] myPrice;

    private float myModifierTotal;

    /*
    -----constructor------
    modifier array
    price array
    */



    public upgrade_class(float[] mod, int[] price)
    {
        if (mod.Length == price.Length)
        {
            myModifier = new float[mod.Length];
            myPrice = new int[price.Length];

            for (int i = 0; i < mod.Length; i++)
            {
                myModifier[i] = mod[i];
                myPrice[i] = price[i];
            }
            myModifierCount = 0;
            myModifierTotal = 0;
        }
    }

    //main function to call when adding upgrade
    public void Upgrade()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (CanUpgrade() && player.GetComponent<player_control>().Transaction(-myPrice[myModifierCount]))
        {
            myModifierTotal += myModifier[myModifierCount];
            myModifierCount++;
        }

    }

    public float GetModifierTotal()
    {
        return myModifierTotal;
    }

    public int GetNumUpgrades()
    {
        return myModifier.Length;
    }

    public int GetPrice()
    {
        return myPrice[myModifierCount];
    }

    public bool CanUpgrade()
    {
        return (myModifierCount < myModifier.Length);
    }
}
