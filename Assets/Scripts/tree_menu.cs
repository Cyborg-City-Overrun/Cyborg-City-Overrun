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

    //damage
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

    //health
    public void UnlockHealthIncrease(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Health").GetBranchWithTagAndLevel("HealthIncrease", level).Unlock();
    }
    public void UnlockHealtRecovery(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Health").GetBranchWithTagAndLevel("HealthRecovery", level).Unlock();
    }
    public void UnlockHealthRegen(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Health").GetBranchWithTagAndLevel("HealthRegen", level).Unlock();
    }

    //energy
    public void UnlockAttackEnergy(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Energy").GetBranchWithTagAndLevel("AttackEnergy", level).Unlock();
    }
    public void UnlockRunEnergy(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Energy").GetBranchWithTagAndLevel("RunEnergy", level).Unlock();
    }
    public void UnlockWalkSpeed(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Energy").GetBranchWithTagAndLevel("WalkSpeed", level).Unlock();
    }
    public void UnlockRunSpeed(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Energy").GetBranchWithTagAndLevel("RunSpeed", level).Unlock();
    }
    public void UnlockEnergyRegen(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Energy").GetBranchWithTagAndLevel("EnergyRegen", level).Unlock();
    }
}
