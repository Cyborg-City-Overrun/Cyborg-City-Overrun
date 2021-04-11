using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display_controls : MonoBehaviour
{

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        SetControl();
    }

    public void SetControl()
    {
        foreach (KeyCode kc in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kc))
            {
                player.GetComponent<player_control>().SetInteractKey(kc);
                print("User pressed : " + kc.ToString());
            }
        }
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}
