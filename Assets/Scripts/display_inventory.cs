using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_inventory : MonoBehaviour
{
    public GameObject[] slots;

    public GameObject[] weapons;
    public GameObject[] potions;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        DisplayAll();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            close();
        }
    }

    public void close()
    {
        gameObject.SetActive(false);
    }

    public void DisplayAll()
    {
        DisplayWeapons(0);
        DisplayPotions(weapons.Length);

    }

    public void DisplayWeapons(int startingIndex)
    {
        for (int i = startingIndex; i < slots.Length; i++)
        {
            if (i < weapons.Length + startingIndex)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = weapons[i - startingIndex].gameObject.GetComponent<inventory_item>().displayImage;
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);

                slots[i].transform.GetChild(1).GetComponent<Text>().text = weapons[i - startingIndex].gameObject.GetComponent<inventory_item>().displayName;
                slots[i].transform.GetChild(2).GetComponent<Text>().text = "";

            }
            else
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);

                slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
                slots[i].transform.GetChild(2).GetComponent<Text>().text = "";
            }
        }
    }

    public void DisplayPotions(int startingIndex)
    {
        for (int i = startingIndex; i < slots.Length; i++)
        {
            if (i < potions.Length + startingIndex)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = potions[i - startingIndex].gameObject.GetComponent<inventory_item>().displayImage;
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);

                slots[i].transform.GetChild(1).GetComponent<Text>().text = potions[i - startingIndex].gameObject.GetComponent<inventory_item>().displayName;
                slots[i].transform.GetChild(2).GetComponent<Text>().text = potions[i - startingIndex].gameObject.GetComponent<inventory_item>().displayNumber.ToString();
            }
            else
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);

                slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
                slots[i].transform.GetChild(2).GetComponent<Text>().text = "";

            }
        }
    }
}
