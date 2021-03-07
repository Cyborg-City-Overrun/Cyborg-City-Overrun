using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_weapon_display : MonoBehaviour
{
    private GameObject myPlayer;
    public GameObject image;
    public GameObject weapons;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //update image to be whatever image the equipped weapon is
        image.transform.GetComponent<Image>().sprite = weapons.transform.GetChild(myPlayer.GetComponent<player_control>().GetSword().getID()).GetComponent<inventory_item>().displayImage;
    }
}
