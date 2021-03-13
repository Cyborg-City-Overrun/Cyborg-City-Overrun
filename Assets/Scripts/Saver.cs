using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public player_control player;
    private string[] potionSaveNames = { "HealthPotionAmt", "EnergyPotionAmt", "AttackPotionAmt" };
    private string[] materialSaveNames = { "IronAmt" };
    private string[] swordSaveNames = { "StarterSword", "GreatSword", "Dagger" };
    // Start is called before the first frame update
    void Start()
    {
      
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

            print(swordSaveNames[i] + ": " + PlayerPrefs.GetInt(swordSaveNames[i]));
        }

        PlayerPrefs.SetFloat("Health", player.getMyHealth());
        PlayerPrefs.SetFloat("Energy", player.getMyEnergy());


        for (int i = 0; i < materialSaveNames.Length; i++)
        {
            PlayerPrefs.SetInt(materialSaveNames[i], player.myMaterials[i].GetComponent<number_in_inventory>().getNum());
            print(materialSaveNames[i] + ": " + PlayerPrefs.GetInt(materialSaveNames[i]));
        }
    }


    
    public void newGame()
    {
        PlayerPrefs.SetInt("MoneyAmt", 100);

        for (int i = 0; i < materialSaveNames.Length; i++)
        {
            PlayerPrefs.SetInt(materialSaveNames[i], 0);
        }

        for (int i = 0; i < potionSaveNames.Length; i++)
        {
            PlayerPrefs.SetInt(potionSaveNames[i], 2);
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
    }
}
