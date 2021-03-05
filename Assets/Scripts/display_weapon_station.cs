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
        updateBuildButton();
    }
    public void updateBuildButton()
    {
        buildButton.transform.GetComponent<Button>().onClick.RemoveAllListeners();
        buildButton.transform.GetComponent<Button>().onClick.AddListener(buildButtonCommand);
    }

    public void buildButtonCommand()
    {
        myPlayer.GetComponent<sword_list>().unlockWeapon(currentWeapon);
    }
}
