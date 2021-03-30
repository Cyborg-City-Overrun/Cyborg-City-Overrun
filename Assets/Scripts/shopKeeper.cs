using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopKeeper : MonoBehaviour
{

    public dialogueParser dialogue, firstInteraction, bossMono, bossDead;
    public dialogueParser[] randTalk;
    private GameObject player;
    private bool firstInteracted = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogue.setIsInteracted(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool doInteract(bool isItFirst)
    {
        bool firstInteract = isItFirst;
        if (firstInteract == false)
        {
            firstInteraction.setIsInteracted(true);
        }
        else
        {
            randTalk[(int)(Random.Range(0, 5))].setIsInteracted(true);
        }

        return true;
    }

    public void bossInteract(bool alive)
    {
        if (alive == true)
        {
            bossMono.setIsInteracted(true);
        }
        else
        {
            bossDead.setIsInteracted(true);
        }
    }

}
