using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeDrop : MonoBehaviour
{
    public enum types { red, green, yellow };
    public types type;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Interact")
        {
            switch(type)
            {
                case types.red:
                    player.GetComponent<player_control>().AddSkillPoints("Red");
                    break;
                case types.green:
                    player.GetComponent<player_control>().AddSkillPoints("Green");
                    break;
                case types.yellow:
                    player.GetComponent<player_control>().AddSkillPoints("Yellow");
                    break;
            }
            player.GetComponent<player_control>().OpenUpgradeMenu();
            Destroy(gameObject);
        }
    }
}
