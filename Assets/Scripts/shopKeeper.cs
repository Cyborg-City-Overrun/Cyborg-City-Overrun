using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopKeeper : MonoBehaviour
{

    public dialogueParser dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogue.setIsInteracted(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
