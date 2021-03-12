using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_weapon_station : MonoBehaviour
{

    public GameObject purchaseButton;
    public GameObject upgradeDamageButton;

    public Text weaponName;

    public int currentWeapon = 0;

    private GameObject myPlayer;

    public GameObject[] weapons;

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
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == currentWeapon)
            {
                weapons[i].transform.GetChild(2).GetComponent<Text>().text = "[E]";
            }
            else
            {
                weapons[i].transform.GetChild(2).GetComponent<Text>().text = "";
            }
        }
        //display();
        updatePurchaseButton();
        updateUpgradeDamageButton();
    }
    public void updatePurchaseButton()
    {
        if (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUnlocked() == true)
        {
            purchaseButton.transform.GetChild(4).GetComponent<Text>().text = "Owned";

            purchaseButton.transform.GetComponent<Button>().onClick.RemoveAllListeners();
        }
        else
        {
            purchaseButton.transform.GetChild(4).GetComponent<Text>().text = myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetPrice().ToString();
            
            purchaseButton.transform.GetComponent<Button>().onClick.RemoveAllListeners();
            purchaseButton.transform.GetComponent<Button>().onClick.AddListener(purchaseButtonCommand);
        }
    }

    public void purchaseButtonCommand()
    {
        if (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUnlocked() == false)
        {
            if (myPlayer.GetComponent<player_control>().Transaction(-myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetPrice()))
            {
                myPlayer.GetComponent<sword_list>().unlockWeapon(currentWeapon);
            }
        }
    }

    public void updateUpgradeDamageButton()
    {
        if (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).CanUpgradeDamage())
        {
            //display level
            upgradeDamageButton.transform.GetChild(2).GetComponent<Text>().text = "+" + myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUpgradeModifierNextDamage().ToString();
            
            //display amount increase
            upgradeDamageButton.transform.GetChild(3).GetComponent<Text>().text = "lvl " + (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUpgradeCountDamage() + 1).ToString();

            //display price
            upgradeDamageButton.transform.GetChild(4).GetComponent<Text>().text = myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUpgradePriceDamage().ToString();

            upgradeDamageButton.transform.GetComponent<Button>().onClick.RemoveAllListeners();
            upgradeDamageButton.transform.GetComponent<Button>().onClick.AddListener(UpgradeDamageButtonCommand);
        }
        else
        {
            upgradeDamageButton.transform.GetChild(2).GetComponent<Text>().text = "";
            upgradeDamageButton.transform.GetChild(3).GetComponent<Text>().text = "lvl " + (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUpgradeCountDamage() + 1).ToString();
            upgradeDamageButton.transform.GetChild(4).GetComponent<Text>().text = "Max";

            upgradeDamageButton.transform.GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void UpgradeDamageButtonCommand()
    {
        if (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUnlocked() == true)
        {
            myPlayer.GetComponent<sword_list>().getSword(currentWeapon).UpgradeDamage();
        }
    }
}
