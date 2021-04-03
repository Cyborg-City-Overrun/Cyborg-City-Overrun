using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monoboss : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip[] bossMusic;
    public GameObject boss;
    public dialogueParser parser;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        boss.GetComponent<shopKeeper>().bossInteract(true);
        Destroy(gameObject);
        audio.loop = true;
        audio.clip = bossMusic[0];
        audio.Play();

    }
}
