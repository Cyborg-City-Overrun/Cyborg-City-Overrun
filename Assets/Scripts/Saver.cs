using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public player_control player;
    private string[] potionSaveNames = { "HealthPotionAmt", "EnergyPotionAmt", "AttackPotionAmt" };
    private string[] materialSaveNames = { "Iron", "Steel", "Copper" };
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
        
        for(int i = 0; i < player.myPotions.Length; i++)
        {
            PlayerPrefs.SetInt(potionSaveNames[i], player.myPotions[i].GetComponent<potions>().getMyNumberInInventory());
        }

        PlayerPrefs.SetFloat("Health", player.getMyHealth());
        PlayerPrefs.SetFloat("Energy", player.getMyEnergy());


        for(int i = 0; i<materialSaveNames.Length; i++)
        {
            PlayerPrefs.SetInt(materialSaveNames[i], player.myMaterials[i].GetComponent<number_in_inventory>().getNum());
            print(materialSaveNames[i] + ": " + PlayerPrefs.GetInt(materialSaveNames[i]));
        }


    }

    public string [] getPotionSaveNames()
    {
        return potionSaveNames;
    }

    public string[] getMaterialSaveNames()
    {
        return materialSaveNames;
    }
}
