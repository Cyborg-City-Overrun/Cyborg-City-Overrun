using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_shop : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject[] potions;
    public Sprite locked;
    public GameObject myPlayer;
    public enum Displays { potions };
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
        DisplayPotions(0);
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
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = list[i - startingIndex].gameObject.GetComponent<inventory_item>().displayImage;
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);

                //Displays the Item Name
                slots[i].transform.GetChild(1).GetComponent<Text>().text = list[i - startingIndex].gameObject.GetComponent<inventory_item>().displayName;
                //Displays the Item Amount
                slots[i].transform.GetChild(2).GetComponent<Text>().text = list[i - startingIndex].gameObject.GetComponent<inventory_item>().displayNumber.ToString();
                //Displays the Item Price
                slots[i].transform.GetChild(3).GetComponent<Text>().text = list[i - startingIndex].gameObject.GetComponent<potions>().getPrice().ToString();


                slots[i].transform.GetComponent<Button>().onClick.RemoveAllListeners();
                slots[i].transform.GetComponent<Button>().onClick.AddListener(list[i - startingIndex].gameObject.GetComponent<inventory_item>().buttonActionShop);
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

