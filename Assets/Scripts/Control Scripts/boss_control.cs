using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_control : MonoBehaviour
{

    public GameObject boss;
    public GameObject bossDying;

    // Update is called once per frame

    void Update()
    {

    }

    private void OnDisable()
    {
        boss.GetComponent<shopKeeper>().bossInteract(false);
        Instantiate(bossDying.gameObject, new Vector3(this.transform.position.x, this.transform.position.y, -1), Quaternion.identity);
    }
}
