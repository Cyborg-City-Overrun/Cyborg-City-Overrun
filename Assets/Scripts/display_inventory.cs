using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_inventory : MonoBehaviour
{
    public GameObject[] slots;

    public GameObject[] weapons;
    public GameObject[] potions;

    public enum Displays { all, potions, weapons };
    public Displays currentDisplay;


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
        updateDisplay();

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
        currentDisplay = Displays.all;
    }

    public void DisplayWeapons(int startingIndex)
    {
        for (int i = startingIndex; i < slots.Length; i++)
        {
            currentDisplay = Displays.weapons;

            if (i < weapons.Length + startingIndex)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = weapons[i - startingIndex].gameObject.GetComponent<inventory_item>().displayImage;
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);

                slots[i].transform.GetChild(1).GetComponent<Text>().text = weapons[i - startingIndex].gameObject.GetComponent<inventory_item>().displayName;
                slots[i].transform.GetChild(2).GetComponent<Text>().text = "";

                slots[i].transform.GetComponent<Button>().onClick.RemoveAllListeners();
                slots[i].transform.GetComponent<Button>().onClick.AddListener(weapons[i - startingIndex].gameObject.GetComponent<inventory_item>().buttonAction);
            }
            else
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);

                slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
                slots[i].transform.GetChild(2).GetComponent<Text>().text = "";

                slots[i].transform.GetComponent<Button>().onClick.RemoveAllListeners();
            }
        }
    }

    public void DisplayPotions(int startingIndex)
    {
        currentDisplay = Displays.potions;

        for (int i = startingIndex; i < slots.Length; i++)
        {
            if (i < potions.Length + startingIndex)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = potions[i - startingIndex].gameObject.GetComponent<inventory_item>().displayImage;
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);

                slots[i].transform.GetChild(1).GetComponent<Text>().text = potions[i - startingIndex].gameObject.GetComponent<inventory_item>().displayName;
                slots[i].transform.GetChild(2).GetComponent<Text>().text = potions[i - startingIndex].gameObject.GetComponent<inventory_item>().displayNumber.ToString();

                slots[i].transform.GetComponent<Button>().onClick.RemoveAllListeners();
                slots[i].transform.GetComponent<Button>().onClick.AddListener(potions[i - startingIndex].gameObject.GetComponent<inventory_item>().buttonAction);
            }
            else
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);

                slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
                slots[i].transform.GetChild(2).GetComponent<Text>().text = "";

                slots[i].transform.GetComponent<Button>().onClick.RemoveAllListeners();
            }
        }
    }

    public void updateDisplay()
    {
        switch (currentDisplay)
        {
            case Displays.all:
                DisplayAll();
                break;

            case Displays.weapons:
                DisplayWeapons(0);
                break;

            case Displays.potions:
                DisplayPotions(0);
                break;
        }

    }
}
