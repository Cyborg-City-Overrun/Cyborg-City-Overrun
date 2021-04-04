using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    public item[] garunteedLoot;
    public item[] randomLoot;
    public int randomMin;
    private Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Interact")
        {
            //garunteed drops
            Anim.SetBool("isOpened", true);
            for (int i= 0; i < garunteedLoot.Length; i++)
            {
                Instantiate(garunteedLoot[i].gameObject, new Vector3(this.transform.position.x + Random.Range(-1.0f,1.0f), this.transform.position.y - Random.Range(.5f, .75f), -1), Quaternion.identity);
            }

            //random drops
            Anim.SetBool("isOpened", true);
            int lootIndex = Random.Range(randomMin, randomLoot.Length);
            if (lootIndex >= 0)
            {
                Instantiate(randomLoot[lootIndex].gameObject, new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f), this.transform.position.y - Random.Range(-.5f, -1.0f), -1), Quaternion.identity);
            }
            //print("Loot index: " + lootIndex);
            
            Destroy(this.GetComponent<BoxCollider2D>());
        }
    }
}