using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class potion_timer : MonoBehaviour
{
    Text text;
    public GameObject display;
    public GameObject potionToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (potionToDisplay.GetComponent<potions>().getTimer() > 0)
        {
            display.SetActive(true);
            text.text = potionToDisplay.GetComponent<potions>().getTimer().ToString();
        }
        else
        {
            display.SetActive(false);
            text.text = " ";
        }
    }
}
