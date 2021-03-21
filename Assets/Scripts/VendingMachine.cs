using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    // Start is called before the first frame update
    public item[] Loot;
    public int randomAmt;
    public int price;

    public GameObject player;
    public potions vendPotion = new potions();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interact")
        {
            //random drops
            int lootIndex = Random.Range(randomAmt, Loot.Length);
            if (lootIndex >= 0)
            {
                switch (lootIndex)
                {
                    case 0:
                        vendPotion.myID = 0;
                        price = vendPotion.getPrice();
                        if (player.GetComponent<player_control>().Transaction(-price))
                        {
                            Instantiate(Loot[lootIndex].gameObject, new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f), this.transform.position.y - Random.Range(.5f, 1.0f), -1), Quaternion.identity);
                        }
                        break;
                    case 1:
                        vendPotion.myID = 1;
                        price = vendPotion.getPrice();
                        if (player.GetComponent<player_control>().Transaction(-price))
                        {
                            Instantiate(Loot[lootIndex].gameObject, new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f), this.transform.position.y - Random.Range(.5f, 1.0f), -1), Quaternion.identity);
                        }
                        break;
                    case 2:
                        vendPotion.myID = 2;
                        price = vendPotion.getPrice();
                        if (player.GetComponent<player_control>().Transaction(-price))
                        {
                            Instantiate(Loot[lootIndex].gameObject, new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f), this.transform.position.y - Random.Range(.5f, 1.0f), -1), Quaternion.identity);
                        }
                        break;

                }
            }
        }
    }
}