using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class potion_display : MonoBehaviour
{
    Text text;
    public GameObject potionToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = potionToDisplay.GetComponent<potions>().getNumberOfPotions().ToString();
    }
}
