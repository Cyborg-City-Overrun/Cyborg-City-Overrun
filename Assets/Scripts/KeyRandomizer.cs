using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRandomizer : MonoBehaviour
{
    public GameObject[] chestsToRandomize;
    public key[] keys;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            int rand = Random.Range(0, 18);

            chestsToRandomize[rand].tag = "KeyChest";
            chestsToRandomize[rand].GetComponent<Chest>().Key = keys[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
