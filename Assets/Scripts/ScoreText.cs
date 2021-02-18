using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    Text text;
    public static int coinAmount = 100;

    void Start()
    {
        text = GetComponent<Text> ();
    }

    void Update()
    {
        text.text = coinAmount.ToString();
    }
}
