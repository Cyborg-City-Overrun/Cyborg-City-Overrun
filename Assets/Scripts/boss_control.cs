using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_control : MonoBehaviour
{

    public GameObject boss;

    // Update is called once per frame

    void Update()
    {

    }

    private void OnDisable()
    {
        boss.GetComponent<shopKeeper>().bossInteract(false);
    }
}
