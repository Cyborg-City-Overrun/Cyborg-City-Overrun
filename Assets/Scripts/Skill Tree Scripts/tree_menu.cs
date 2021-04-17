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
        player.GetComponent<tree_list>().GetTreeWithTag("Damage").GetBranchWithTagAndLevel("DamageBuff", level).UnlockRed();
    }
    public void UnlockDamageCritBuff(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Damage").GetBranchWithTagAndLevel("DamageCritBuff", level).UnlockRed();
    }
    public void UnlockDamageCritChance(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Damage").GetBranchWithTagAndLevel("DamageCritChance", level).UnlockRed();
    }
    public void UnlockDamageCritStun(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Damage").GetBranchWithTagAndLevel("DamageCritStun", level).UnlockRed();
    }

    //health
    public void UnlockHealthIncrease(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Health").GetBranchWithTagAndLevel("HealthIncrease", level).UnlockGreen();
    }
    public void UnlockHealtRecovery(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Health").GetBranchWithTagAndLevel("HealthRecovery", level).UnlockGreen();
    }
    public void UnlockHealthRegen(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Health").GetBranchWithTagAndLevel("HealthRegen", level).UnlockGreen();
    }

    //energy
    public void UnlockAttackEnergy(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Energy").GetBranchWithTagAndLevel("AttackEnergy", level).UnlockYellow();
    }
    public void UnlockRunEnergy(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Energy").GetBranchWithTagAndLevel("RunEnergy", level).UnlockYellow();
    }
    public void UnlockWalkSpeed(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Energy").GetBranchWithTagAndLevel("WalkSpeed", level).UnlockYellow();
    }
    public void UnlockRunSpeed(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Energy").GetBranchWithTagAndLevel("RunSpeed", level).UnlockYellow();
    }
    public void UnlockEnergyRegen(int level)
    {
        player.GetComponent<tree_list>().GetTreeWithTag("Energy").GetBranchWithTagAndLevel("EnergyRegen", level).UnlockYellow();
    }
}
