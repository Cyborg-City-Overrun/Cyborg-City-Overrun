using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_class
{
    private int myID;
    private string myName;
    private float myDamage;
    private float myAttackEnergy;
    private int mySize; //0, 1, 2 = small, med, large

    public sword_class(int id, string name, float damage, float energy, int size)
    {
        myID = id;
        myName = name;
        myDamage = damage;
        myAttackEnergy = energy;
        setSize(size);
    }

    private void setSize(int size)
    {
        if (size >= 0 && size <= 2)
        {
            mySize = size;
        }
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
}
