using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public player_control player;
    private string[] potionSaveNames = { "HealthPotionAmt", "EnergyPotionAmt", "AttackPotionAmt" };
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

        print("Game Saved!\nCurrent Health: " + PlayerPrefs.GetFloat("Health") + "\nCurrent Energy: " + PlayerPrefs.GetFloat("Energy") + "\nCurrent Amount of Health Potions: " + PlayerPrefs.GetInt(potionSaveNames[0]) + "\nCurrent Amount of Energy Potions: " + PlayerPrefs.GetInt(potionSaveNames[1]) + "\nCurrent Amount of Attack Potions: " + PlayerPrefs.GetInt(potionSaveNames[2]) + "\nCurrent Amount of money: " + PlayerPrefs.GetInt("MoneyAmt"));


    }
}
