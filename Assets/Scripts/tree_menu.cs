using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_menu : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void UnlockDamageBuff(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Damage").GetBranchWithTagAndLevel("DamageBuff", level).Unlock();
        print(player.GetComponent<tree_list>().GetTreeWithTag("Damage").GetActiveBranchWithTag("DamageBuff").GetModifier().ToString());
    }
}
