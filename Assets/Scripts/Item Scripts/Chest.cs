using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    public item[] garunteedLoot;
    public key Key;
    public item[] randomLoot;
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

            if(this.tag=="KeyChest")
            { 
                Instantiate(Key, new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f), this.transform.position.y - Random.Range(.5f, .75f), -1), Quaternion.identity); 
            }

            for (int i = 0; i < garunteedLoot.Length; i++)
            {
                Instantiate(garunteedLoot[i].gameObject, new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f), this.transform.position.y - Random.Range(.5f, .75f), -1), Quaternion.identity);


            }

            //random drops
           
            {
                int lootIndex = Random.Range(0, randomLoot.Length);
                Instantiate(randomLoot[lootIndex].gameObject, new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f), this.transform.position.y - Random.Range(-.5f, -1.0f), -1), Quaternion.identity);

            }
            Destroy(this.GetComponent<BoxCollider2D>());
        }
    }
}
