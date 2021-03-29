using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopKeeper : MonoBehaviour
{

    public dialogueParser dialogue;
    public dialogueParser firstInteraction;
    public dialogueParser[] randTalk;
    private bool firstInteracted = false;
    // Start is called before the first frame update
    void Start()
    {
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

}
