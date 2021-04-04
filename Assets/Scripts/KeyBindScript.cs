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
        keys.Add("Interact", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact", "D")));
        keys.Add("Pause Menu", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Pause Menu", "M")));
        keys.Add("Inventory", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Inventory", "T")));
        keys.Add("Sword Switch", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Sword Switch", "Z")));
        keys.Add("Health Potion", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Health Potion", "F")));
        keys.Add("Energy Potion", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Energy Potion", "G")));
        keys.Add("Attack Buff Potion", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Attack Buff Potion", "H")));

        interact.text = keys["Interact"].ToString();
        pauseMenu.text = keys["Pause Menu"].ToString();
        inventory.text = keys["Inventory"].ToString();
        swordSwitch.text = keys["Sword Switch"].ToString();
        healthPotion.text = keys["Health Potion"].ToString();
        energyPotion.text = keys["Energy Potion"].ToString();
        attackBuffPotion.text = keys["Attack Buff Potion"].ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keys["Interact"])){
            Debug.Log("Interact");
        }
        if (Input.GetKeyDown(keys["Pause Menu"])){
            Debug.Log("Pause Menu");
        }
        if (Input.GetKeyDown(keys["Inventory"])){
            Debug.Log("Inventory");
        }
        if (Input.GetKeyDown(keys["Sword Switch"])){
            Debug.Log("Sword Switch");
        }
        if (Input.GetKeyDown(keys["Health Potion"])){
            Debug.Log("Health Potion");
        }
        if (Input.GetKeyDown(keys["Energy Potion"])){
            Debug.Log("Energy Potion");
        }
        if (Input.GetKeyDown(keys["Attack Buff Potion"])){
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
}
