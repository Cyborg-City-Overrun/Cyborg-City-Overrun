using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class KeyBindScript : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    

    public Text attack, interact, pauseMenu, inventory, swordSwitch, run, healthPotion, energyPotion, attackBuffPotion;

    private GameObject currentKey;

    private KeyCode[] invalidKeys;

    void Start()
    {
        keys.Add("AttackControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("AttackControl", "Space")));
        keys.Add("InteractControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("InteractControl", "E")));
        keys.Add("PauseMenuControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PauseMenuControl", "M")));
        keys.Add("InventoryControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("InventoryControl", "T")));
        keys.Add("SwordSwitchControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("SwordSwitchControl", "Z")));
        keys.Add("RunControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RunControl", "LeftShift")));
        keys.Add("HealthPotionControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("HealthPotionControl", "F")));
        keys.Add("EnergyPotionControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("EnergyPotionControl", "G")));
        keys.Add("AttackBuffPotionControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("AttackBuffPotionControl", "H")));
        
        attack.text = keys["AttackControl"].ToString();
        interact.text = keys["InteractControl"].ToString();
        pauseMenu.text = keys["PauseMenuControl"].ToString();
        inventory.text = keys["InventoryControl"].ToString();
        swordSwitch.text = keys["SwordSwitchControl"].ToString();
        run.text = keys["RunControl"].ToString();
        healthPotion.text = keys["HealthPotionControl"].ToString();
        energyPotion.text = keys["EnergyPotionControl"].ToString();
        attackBuffPotion.text = keys["AttackBuffPotionControl"].ToString();

        invalidKeys = new KeyCode[] { KeyCode.Escape, KeyCode.Return, KeyCode.Backspace,
            KeyCode.F1, KeyCode.F2, KeyCode.F3, KeyCode.F4, KeyCode.F5, KeyCode.F6, KeyCode.F7, KeyCode.F8, 
            KeyCode.F9, KeyCode.F10, KeyCode.F11, KeyCode.F12, KeyCode.F13, KeyCode.F14, KeyCode.F15,
            KeyCode.CapsLock, KeyCode.Mouse0, KeyCode.Mouse1, KeyCode.Mouse2, KeyCode.Mouse3, 
            KeyCode.Mouse4, KeyCode.Mouse5, KeyCode.Mouse6, KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D,
            KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow };
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        GameObject cl = GameObject.FindGameObjectWithTag("ControlList");
        if (cl == null)
        {
            return;
        }
        for (int i = 0; i < cl.transform.childCount; i++)
        {
            Transform child = cl.transform.GetChild(i);
            child.GetChild(0).GetComponent<Text>().text = keys[child.name].ToString();

        }
    }

    void OnGUI()
    {
        if (currentKey != null){
            Event e = Event.current;
            keys[currentKey.name] = KeyCode.None;
            if (e.isKey && CheckKeyAvailable(e)){
                keys[currentKey.name] = e.keyCode;
                //currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    private bool CheckKeyAvailable(Event e)
    {
        GameObject cl = GameObject.FindGameObjectWithTag("ControlList");
        if (cl == null)
        {
            return false;
        }
        for (int i = 0; i < cl.transform.childCount; i++)
        {
            Transform child = cl.transform.GetChild(i);

            if (keys[child.name] == e.keyCode)
            {
                print("INVALID");
                return false;
            }
        }
        for (int i = 0; i < invalidKeys.Length; i++)
        {
            if (invalidKeys[i] == e.keyCode)
            {
                print("INVALID");
                return false;
            }
        }
        return true;
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
        PlayerPrefs.SetString("AttackControl", "Space");
        PlayerPrefs.SetString("InteractControl", "E");
        PlayerPrefs.SetString("PauseMenuControl", "M");
        PlayerPrefs.SetString("InventoryControl", "T");
        PlayerPrefs.SetString("SwordSwitchControl", "Z");
        PlayerPrefs.SetString("RunControl", "LeftShift");
        PlayerPrefs.SetString("HealthPotionControl", "F");
        PlayerPrefs.SetString("EnergyPotionControl", "G");
        PlayerPrefs.SetString("AttackBuffPotionControl", "H");
        PlayerPrefs.Save();

        keys.Clear();

        keys.Add("AttackControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("AttackControl", "Space")));
        keys.Add("InteractControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("InteractControl", "E")));
        keys.Add("PauseMenuControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PauseMenuControl", "M")));
        keys.Add("InventoryControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("InventoryControl", "T")));
        keys.Add("SwordSwitchControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("SwordSwitchControl", "Z")));
        keys.Add("RunControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RunControl", "LeftShift")));
        keys.Add("HealthPotionControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("HealthPotionControl", "F")));
        keys.Add("EnergyPotionControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("EnergyPotionControl", "G")));
        keys.Add("AttackBuffPotionControl", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("AttackBuffPotionControl", "H")));
    }

    public KeyCode GetKey(string key)
    {
        return keys[key];
    }
}
