using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monoboss : MonoBehaviour
{

    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        boss.GetComponent<shopKeeper>().bossInteract(true);
        Destroy(gameObject);
    }
}
