using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioStarter : MonoBehaviour
{
    public dialogueParser parser;
    public AudioSource audio;
    public AudioClip bossMusic;
    public enemy_control boss;
    public bool hasNotEnded = true;
    public player_control player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (parser.getIsEnd() && hasNotEnded)
        {
            audio.clip = bossMusic;
            audio.Play();
            hasNotEnded = false;

        }

        if(boss.getMyHealth() <= 0 || player.getMyHealth() <= 0)
        {
            audio.Stop();
            Destroy(this);
        }
    }
}
