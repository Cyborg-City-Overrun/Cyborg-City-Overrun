using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class number_in_inventory : MonoBehaviour
{
    public int myNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setNum(int num)
    {
        myNum = num;
    }

    public int getNum()
    {
        return myNum;
    }

}
