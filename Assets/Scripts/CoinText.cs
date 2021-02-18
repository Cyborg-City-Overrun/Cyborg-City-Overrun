using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    Text text;
    public static int coinAmount = 100;

    private GameObject myPlayer;

    void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
        text = GetComponent<Text> ();
    }

    void Update()
    {
        coinAmount = myPlayer.GetComponent<player_control>().myMoney;
        text.text = coinAmount.ToString();
    }
}
