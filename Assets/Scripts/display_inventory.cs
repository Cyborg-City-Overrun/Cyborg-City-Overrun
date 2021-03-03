using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_inventory : MonoBehaviour
{
    public GameObject[] slots;

    public GameObject[] weapons;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Display_Items(weapons);
        }
    }

    private void Display_Items(GameObject[] list)
    {
        for (int i = 0; i < slots.Length && i < list.Length; i++)
        {
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = list[i].transform.GetComponent<SpriteRenderer>().sprite;
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);

            slots[i].transform.GetChild(1).GetComponent<Text>().text = list[i].gameObject.name;
        }
    }
}
