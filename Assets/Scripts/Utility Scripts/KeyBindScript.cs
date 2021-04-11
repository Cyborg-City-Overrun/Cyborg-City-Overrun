using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class KeyBindScript : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    

    public Text interact, pauseMenu, inventory, swordSwitch, healthPotion, energyPotion, attackBuffPotion;

    private GameObject currentKey;


    void Start()
    {
        keys.Add("InteractControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("InteractControl", "E")));
        keys.Add("PauseMenuControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PauseMenuControl", "M")));
        keys.Add("InventoryControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("InventoryControl", "T")));
        keys.Add("SwordSwitchControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("SwordSwitchControl", "Z")));
        keys.Add("HealthPotionControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("HealthPotionControl", "F")));
        keys.Add("EnergyPotionControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("EnergyPotionControl", "G")));
        keys.Add("AttackBuffPotionControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("AttackBuffPotionControl", "H")));

        interact.text = keys["InteractControl"].ToString();
        pauseMenu.text = keys["PauseMenuControl"].ToString();
        inventory.text = keys["InventoryControl"].ToString();
        swordSwitch.text = keys["SwordSwitchControl"].ToString();
        healthPotion.text = keys["HealthPotionControl"].ToString();
        energyPotion.text = keys["EnergyPotionControl"].ToString();
        attackBuffPotion.text = keys["AttackBuffPotionControl"].ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keys["InteractControl"])){
            Debug.Log("Interact");
        }
        if (Input.GetKeyDown(keys["PauseMenuControl"])){
            Debug.Log("Pause Menu");
        }
        if (Input.GetKeyDown(keys["InventoryControl"])){
            Debug.Log("Inventory");
        }
        if (Input.GetKeyDown(keys["SwordSwitchControl"])){
            Debug.Log("Sword Switch");
        }
        if (Input.GetKeyDown(keys["HealthPotionControl"])){
            Debug.Log("Health Potion");
        }
        if (Input.GetKeyDown(keys["EnergyPotionControl"])){
            Debug.Log("Energy Potion");
        }
        if (Input.GetKeyDown(keys["AttackBuffPotionControl"])){
            Debug.Log("Attack Buff Potion");
        }
    }

    void OnGUI()
    {
        if (currentKey != null){
            Event e = Event.current;
            if (e.isKey){
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked){
        currentKey = clicked;
    }

    public void SaveKeys(){
        foreach(var key in keys){
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }
    public void ResetKeys()
    {
        PlayerPrefs.SetString("InteractControl", "E");
        PlayerPrefs.SetString("PauseMenuControl", "M");
        PlayerPrefs.SetString("InventoryControl", "T");
        PlayerPrefs.SetString("SwordSwitchControl", "Z");
        PlayerPrefs.SetString("HealthPotionControl", "F");
        PlayerPrefs.SetString("EnergyPotionControl", "G");
        PlayerPrefs.SetString("AttackBuffPotionControl", "H");
        PlayerPrefs.Save();
    }
}
