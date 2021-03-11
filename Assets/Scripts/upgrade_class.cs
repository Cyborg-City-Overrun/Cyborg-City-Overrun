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



    public upgrade_class(float[] damage, int[] price)
    {
        if (damage.Length == price.Length)
        {
            for (int i = 0; i < damage.Length; i++)
            {
                myModifier[i] = damage[i];
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
        if (myModifierCount < myModifier.Length && player.GetComponent<player_control>().Transaction(myPrice[myModifierCount]))
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
}
