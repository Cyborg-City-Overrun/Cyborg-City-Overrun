using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    public item[] loot;
    public int maxLoot;
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
        if(collision.tag=="Player")
        {
            Anim.SetBool("isOpened", true);
            int lootIndex = Random.Range(-1, maxLoot+1);
            if(lootIndex>=0)
            {
                Instantiate(loot[lootIndex].gameObject, new Vector3(this.transform.position.x, this.transform.position.y + 1,-1), Quaternion.identity);
            }
            print("Loot index: " + lootIndex);
            Destroy(this.GetComponent<BoxCollider2D>());
        }
    }
}
