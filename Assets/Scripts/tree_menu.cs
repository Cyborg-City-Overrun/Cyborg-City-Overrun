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
    }
    public void UnlockDamageCritBuff(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Damage").GetBranchWithTagAndLevel("DamageCritBuff", level).Unlock();
    }
    public void UnlockDamageCritChance(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Damage").GetBranchWithTagAndLevel("DamageCritChance", level).Unlock();
    }
    public void UnlockDamageCritStun(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Damage").GetBranchWithTagAndLevel("DamageCritStun", level).Unlock();
    }
}
