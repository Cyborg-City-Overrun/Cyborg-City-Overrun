using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopKeeper : MonoBehaviour
{

    public dialogueParser dialogue, firstInteraction, bossMono, bossDead;
    public dialogueParser[] randTalk;
    private GameObject player;
    private bool firstInteracted = false;
    private int[] randIndex = { 0, 1, 2 };
    private int totalClick = 0;
    public Image talkButtonImage;
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
        totalClick++;
        bool isRandPicked = false;
        bool firstInteract = isItFirst;
        if(totalClick<=4)
        {
            if (firstInteract == false)
            {
                firstInteraction.setIsInteracted(true);
            }
            else
            {
                while (!isRandPicked)
                {
                    int totalNeg = 0;
                    foreach (int num in randIndex)
                    {
                        if (num == -1)
                        {
                            totalNeg++;
                        }
                    }

                    if (totalNeg > 3)
                    {
                        isRandPicked = true;
                        print(":o");
                    }

                    else
                    {
                        int rand = (int)(Random.Range(0, 3));
                        if (randIndex[rand] != -1)
                        {
                            randTalk[rand].setIsInteracted(true);
                            randIndex[rand] = -1;
                            isRandPicked = true;
                        }
                    }

                }
            }
        }
        else
        {
            talkButtonImage.color = new Color(0.18f, 0.16f, 0.25f,1);
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
