using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public player_control player;
    private string[] potionSaveNames = { "HealthPotionAmt", "EnergyPotionAmt", "AttackPotionAmt" };
    private string[] materialSaveNames = { "IronAmt" };
    private string[] swordSaveNames = { "StarterSword", "GreatSword", "Dagger" };
    private string[] starterSwordUpgrades = { "SSDamage", "SSEnergy", "SSCrit" };
    private string[] greatSwordUpgrades = { "GSDamage", "GSEnergy", "GSCrit" };
    private string[] daggerUpgrades = { "DDamage", "DEnergy", "DCrit" };

    public string[,] upgrades = new string[3, 3];


    private KeyBindScript keyScript = new KeyBindScript();


    // Start is called before the first frame update
    void Start()
    {
        setUpgradeMatrix();

        loadUpgrades();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveGame()
    {

        PlayerPrefs.SetInt("MoneyAmt", player.myMoney);

        for (int i = 0; i < player.myPotions.Length; i++)
        {
            PlayerPrefs.SetInt(potionSaveNames[i], player.myPotions[i].GetComponent<potions>().getMyNumberInInventory());
        }

        for (int i = 0; i < player.myMaterials.Length; i++)
        {
            PlayerPrefs.SetInt(materialSaveNames[i], player.myMaterials[i].GetComponent<number_in_inventory>().getNum());
   
        }

        for (int i = 0; i < swordSaveNames.Length; i++)
        {
            if (player.getSwordList().getSword(i).GetUnlocked())
            {
                PlayerPrefs.SetInt(swordSaveNames[i], 1);
            }
            else PlayerPrefs.SetInt(swordSaveNames[i], 0);

        }

        for (int i = 0; i < starterSwordUpgrades.Length; i++)
        {
            upgrade_class[] allUp = player.getSwordList().getSword(i).getAllUpgrades();
            for (int j = 0; j < swordSaveNames.Length; j++)
            {
                PlayerPrefs.SetInt(upgrades[i, j], allUp[j].Save());
            }
        }
        

        PlayerPrefs.SetFloat("Health", player.getMyHealth());
        PlayerPrefs.SetFloat("Energy", player.getMyEnergy());


        for (int i = 0; i < materialSaveNames.Length; i++)
        {
            PlayerPrefs.SetInt(materialSaveNames[i], player.myMaterials[i].GetComponent<number_in_inventory>().getNum());
            //print(materialSaveNames[i] + ": " + PlayerPrefs.GetInt(materialSaveNames[i]));
        }
    }


    
    public void newGame()
    {

        setUpgradeMatrix();

        for(int x = 0; x < 3; x++)
        {
            for(int y = 0; y < 3; y++)
            {
                PlayerPrefs.SetInt(upgrades[x, y], 0);
            }
        }

        PlayerPrefs.SetInt("MoneyAmt", 100);

        for (int i = 0; i < materialSaveNames.Length; i++)
        {
            PlayerPrefs.SetInt(materialSaveNames[i], 0);
        }

        for (int i = 0; i < potionSaveNames.Length; i++)
        {
            PlayerPrefs.SetInt(potionSaveNames[i], 0);
        }

     

        for (int i = 0; i < swordSaveNames.Length; i++)
        {
            if (i == 0)
            {
                PlayerPrefs.SetInt("StarterSword", 1);
            }
            else PlayerPrefs.SetInt(swordSaveNames[i], 0);

        }


        PlayerPrefs.SetFloat("Health", 100f);
        PlayerPrefs.SetFloat("Energy", 100f);

        keyScript.ResetKeys();
        
    }

    public void loadUpgrades()
    {

        for (int i = 0; i < starterSwordUpgrades.Length; i++)
        {
            upgrade_class[] allUp = player.getSwordList().getSword(i).getAllUpgrades();
            for (int j = 0; j < swordSaveNames.Length; j++)
            {
                allUp[j].Load(PlayerPrefs.GetInt(upgrades[i, j]));
            }
        }
    }

    void setUpgradeMatrix()
    {
        for (int i = 0; i < 3; i++)
        {
            upgrades[0, i] = starterSwordUpgrades[i];
            upgrades[1, i] = greatSwordUpgrades[i];
            upgrades[2, i] = daggerUpgrades[i];
        }
    }
}
