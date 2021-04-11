using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VendingMachine : MonoBehaviour
{
    // Start is called before the first frame update
    public item[] Loot;
    public int randomAmt;
    public bool vend;

    public GameObject player;
    public GameObject[] myPotions;



    void Start()
    {
        vend = false;
        player = GameObject.FindGameObjectWithTag("Player");
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
            if (vend == false)
            {
                vend = true;
                int lootIndex = Random.Range(randomAmt, Loot.Length);
                if (lootIndex >= 0)
                {
                    switch (lootIndex)
                    {
                        case 0:
                            if (player.GetComponent<player_control>().Transaction(-myPotions[lootIndex].GetComponent<potions>().getVendPrice()))
                            {
                                Instantiate(Loot[lootIndex].gameObject, new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f), this.transform.position.y - Random.Range(1.0f, 1.5f), -1), Quaternion.identity);
                            }
                            break;
                        case 1:
                            if (player.GetComponent<player_control>().Transaction(-myPotions[lootIndex].GetComponent<potions>().getVendPrice()))
                            {
                                Instantiate(Loot[lootIndex].gameObject, new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f), this.transform.position.y - Random.Range(1.0f, 1.5f), -1), Quaternion.identity);
                            }
                            break;
                        case 2:
                            if (player.GetComponent<player_control>().Transaction(-myPotions[lootIndex].GetComponent<potions>().getVendPrice()))
                            {
                                Instantiate(Loot[lootIndex].gameObject, new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f), this.transform.position.y - Random.Range(1.0f, 1.5f), -1), Quaternion.identity);
                            }
                            break;

                    }
                }
                StartCoroutine(waitNow());
            }
            else
            {
            }
            //Destroy(this.gameObject);

        }
    }

    private IEnumerator waitNow()
    {
        yield return new WaitForSeconds(.5f);
        vend = false;
    }
}