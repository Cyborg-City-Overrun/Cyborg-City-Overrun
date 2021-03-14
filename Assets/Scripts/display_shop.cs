using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_shop : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject[] materials;
    public GameObject[] potions;
    public Sprite locked;
    public GameObject myPlayer;
    public enum Displays { all, potions, materials };
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
        DisplayWeaponItems(0);
        DisplayPotions(materials.Length);
        currentDisplay = Displays.all;
    }

    public void DisplayWeaponItems(int startingIndex)
    {
        currentDisplay = Displays.materials;

        DisplayMenu(materials, startingIndex);
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

            case Displays.materials:
                DisplayWeaponItems(0);
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
                //Displays the Item Image
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = list[i - startingIndex].gameObject.GetComponent<shop_items>().displayImage;
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);

                //Displays the Item Name
                slots[i].transform.GetChild(1).GetComponent<Text>().text = list[i - startingIndex].gameObject.GetComponent<shop_items>().displayName;
                //Displays the Item Amount
                slots[i].transform.GetChild(2).GetComponent<Text>().text = list[i - startingIndex].gameObject.GetComponent<shop_items>().displayNumber.ToString();


                slots[i].transform.GetComponent<Button>().onClick.RemoveAllListeners();
                slots[i].transform.GetComponent<Button>().onClick.AddListener(list[i - startingIndex].gameObject.GetComponent<shop_items>().buttonAction);
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

