using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_weapon_station : MonoBehaviour
{

    public GameObject buildButton;

    public Text weaponName;

    public int currentWeapon = 0;

    private GameObject myPlayer;

    public GameObject[] weapons;

    public GameObject[] slots;
    public GameObject[] materials;

    private void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        updateDisplay();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void setWeapon(int id)
    {
        currentWeapon = id;
    }

    private void updateDisplay()
    {
        weaponName.text = myPlayer.GetComponent<sword_list>().getSword(currentWeapon).getName();
        displayMaterials();
        updateBuildButton();
    }
    public void updateBuildButton()
    {
        if (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).getUnlocked() == true)
        {
            buildButton.transform.GetChild(2).GetComponent<Text>().text = "Built";
        }
        else
        {
            buildButton.transform.GetChild(2).GetComponent<Text>().text = "";
        }

        buildButton.transform.GetComponent<Button>().onClick.RemoveAllListeners();
        buildButton.transform.GetComponent<Button>().onClick.AddListener(buildButtonCommand);
    }

    public void buildButtonCommand()
    {
        if (weapons[currentWeapon].GetComponent<weapon_build_requirements>().num[0] <= materials[0].gameObject.GetComponent<number_in_inventory>().getNum() && myPlayer.GetComponent<sword_list>().getSword(currentWeapon).getUnlocked() == false)
        {

            materials[0].gameObject.GetComponent<number_in_inventory>().setNum(materials[0].gameObject.GetComponent<number_in_inventory>().getNum() - weapons[currentWeapon].GetComponent<weapon_build_requirements>().num[0]);

            myPlayer.GetComponent<sword_list>().unlockWeapon(currentWeapon);

        }
    }


    
    public void displayMaterials()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < materials.Length)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = materials[i].gameObject.GetComponent<inventory_item>().displayImage;
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);

                slots[i].transform.GetChild(1).GetComponent<Text>().text = materials[i].gameObject.GetComponent<inventory_item>().displayName;
                slots[i].transform.GetChild(2).GetComponent<Text>().text = materials[i].gameObject.GetComponent<inventory_item>().displayNumber.ToString() + " / " + weapons[currentWeapon].GetComponent<weapon_build_requirements>().num[i].ToString();

                slots[i].transform.GetComponent<Button>().onClick.RemoveAllListeners();
                slots[i].transform.GetComponent<Button>().onClick.AddListener(materials[i].gameObject.GetComponent<inventory_item>().buttonAction);
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
