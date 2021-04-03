using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    Text text;
    public static int coinAmount = 100;

    private GameObject myPlayer;

    //Function to make the coin text, set to 100
    void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
        text = GetComponent<Text> ();
    }

    //Function that continues to update the coin tracker
    //everytime the player gains more coins
    void Update()
    {
        coinAmount = myPlayer.GetComponent<player_control>().myMoney;
        text.text = coinAmount.ToString();
    }
}
