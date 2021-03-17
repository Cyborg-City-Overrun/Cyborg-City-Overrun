using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_weapon_station : MonoBehaviour
{

    public GameObject purchaseButton;
    public GameObject upgradeDamageButton;
    public GameObject upgradeEnergyButton;
    public GameObject upgradeCritButton;

    public Text weaponName;

    public int currentWeapon = 0;

    private GameObject myPlayer;

    public GameObject[] weapons;


    public GameObject statDamage;
    public GameObject statEnergy;
    public GameObject statCrit;

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
        UpdatePurchaseButton();
        UpdateUpgradeDamageButton();
        UpdateUpgradeEnergyButton();
        UpdateUpgradeCritButton();

        UpdateStats();
    }

    //purchase
    public void UpdatePurchaseButton()
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

    //damaage
    public void UpdateUpgradeDamageButton()
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

    //energy
    public void UpdateUpgradeEnergyButton()
    {
        if (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).CanUpgradeEnergy())
        {
            //display level
            upgradeEnergyButton.transform.GetChild(2).GetComponent<Text>().text = "" + myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUpgradeModifierNextEnergy().ToString();

            //display amount increase
            upgradeEnergyButton.transform.GetChild(3).GetComponent<Text>().text = "lvl " + (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUpgradeCountEnergy() + 1).ToString();

            //display price
            upgradeEnergyButton.transform.GetChild(4).GetComponent<Text>().text = myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUpgradePriceEnergy().ToString();

            upgradeEnergyButton.transform.GetComponent<Button>().onClick.RemoveAllListeners();
            upgradeEnergyButton.transform.GetComponent<Button>().onClick.AddListener(UpgradeEnergyButtonCommand);
        }
        else
        {
            upgradeEnergyButton.transform.GetChild(2).GetComponent<Text>().text = "";
            upgradeEnergyButton.transform.GetChild(3).GetComponent<Text>().text = "lvl " + (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUpgradeCountEnergy() + 1).ToString();
            upgradeEnergyButton.transform.GetChild(4).GetComponent<Text>().text = "Max";

            upgradeEnergyButton.transform.GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void UpgradeEnergyButtonCommand()
    {
        if (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUnlocked() == true)
        {
            myPlayer.GetComponent<sword_list>().getSword(currentWeapon).UpgradeEnergy();
        }
    }

    //crit
    public void UpdateUpgradeCritButton()
    {
        if (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).CanUpgradeCrit())
        {
            //display level
            upgradeCritButton.transform.GetChild(2).GetComponent<Text>().text = "+" + myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUpgradeModifierNextCrit().ToString();

            //display amount increase
            upgradeCritButton.transform.GetChild(3).GetComponent<Text>().text = "lvl " + (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUpgradeCountCrit() + 1).ToString();

            //display price
            upgradeCritButton.transform.GetChild(4).GetComponent<Text>().text = myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUpgradePriceCrit().ToString();

            upgradeCritButton.transform.GetComponent<Button>().onClick.RemoveAllListeners();
            upgradeCritButton.transform.GetComponent<Button>().onClick.AddListener(UpgradeCritButtonCommand);
        }
        else
        {
            upgradeCritButton.transform.GetChild(2).GetComponent<Text>().text = "";
            upgradeCritButton.transform.GetChild(3).GetComponent<Text>().text = "lvl " + (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUpgradeCountEnergy() + 1).ToString();
            upgradeCritButton.transform.GetChild(4).GetComponent<Text>().text = "Max";

            upgradeCritButton.transform.GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void UpgradeCritButtonCommand()
    {
        if (myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUnlocked() == true)
        {
            myPlayer.GetComponent<sword_list>().getSword(currentWeapon).UpgradeCrit();
        }
    }

    //Stats display
    public void UpdateStats()
    {
        statDamage.transform.GetChild(0).GetComponent<Text>().text = myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetBaseDamageWithModifier().ToString();
        statEnergy.transform.GetChild(0).GetComponent<Text>().text = myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetAttackEnergyWithModifier().ToString();
        statCrit.transform.GetChild(0).GetComponent<Text>().text = myPlayer.GetComponent<sword_list>().getSword(currentWeapon).GetUpgradeModifierTotalCrit() .ToString();
    }
}
