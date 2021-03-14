using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_inventory : MonoBehaviour
{
    public GameObject[] slots;

    public GameObject[] weapons;
    public GameObject[] potions;

    public Sprite locked;

    public GameObject myPlayer;

    public enum Displays { all, potions, weapons };
    public Displays currentDisplay;


    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
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
        currentDisplay = Displays.weapons;

        DisplayMenu(weapons, startingIndex);
    }

    public void DisplayPotions(int startingIndex)
    {
        currentDisplay = Displays.potions;

        DisplayMenu(potions, startingIndex);
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

    public void DisplayMenu(GameObject[] list, int startingIndex)
    {
        for (int i = startingIndex; i < slots.Length; i++)
        {
            if (i < list.Length + startingIndex)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = list[i - startingIndex].gameObject.GetComponent<inventory_item>().displayImage;
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);

                slots[i].transform.GetChild(1).GetComponent<Text>().text = list[i - startingIndex].gameObject.GetComponent<inventory_item>().displayName;
                slots[i].transform.GetChild(2).GetComponent<Text>().text = list[i - startingIndex].gameObject.GetComponent<inventory_item>().displayNumber.ToString();

                slots[i].transform.GetComponent<Button>().onClick.RemoveAllListeners();
                slots[i].transform.GetComponent<Button>().onClick.AddListener(list[i - startingIndex].gameObject.GetComponent<inventory_item>().buttonActionInventory);

                //if it is weapon
                if (list[i - startingIndex].gameObject.tag == "Weapon")
                {
                    //dont display number
                    slots[i].transform.GetChild(2).GetComponent<Text>().text = "";

                    //if equipped Sword
                    if (myPlayer.GetComponent<player_control>().GetSword().GetID() == list[i - startingIndex].gameObject.GetComponent<inventory_item>().displayNumber)
                    {
                        //show equipped
                        slots[i].transform.GetChild(2).GetComponent<Text>().text = "[E]";
                    }
                    
                    //if it is locked
                    if (myPlayer.GetComponent<sword_list>().getSword(list[i - startingIndex].gameObject.GetComponent<inventory_item>().displayNumber).GetUnlocked() == false)
                    {
                        slots[i].transform.GetChild(0).GetComponent<Image>().sprite = locked;
                        slots[i].transform.GetChild(1).GetComponent<Text>().text = "Locked";
                    }
                }
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
}
