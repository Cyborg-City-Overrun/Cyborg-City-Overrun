using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Each tree can have any number of branches with any number of tags

Each tree will have one "root" branch

The root branch is the requirement for the first upgrade (is is not visible)

Each branch will have a "base" branch for each type of upgrade (labeled by their tags, also not visible)

Each tag will have a base branch on top of whatever other branches there are.

The base branches are not a requirement for anything

The base branches are used to have an active tag before the modified upgrades are purchased

The base branch holds a tag and a base modifier

*/

public class tree_list : MonoBehaviour
{
    //damage tree
    skill_tree_branch damageRoot;
    skill_tree_branch damageBuffBase, damageBuffI, damageBuffII, damageBuffIII, damageBuffIV;
    skill_tree_branch damageCritBuffBase, damageCritBuffI, damageCritBuffII;
    skill_tree_branch damageCritChanceBase, damageCritChanceI, damageCritChanceII;
    skill_tree_branch damageCritStunBase, damageCritStunI, damageCritStunII;
    skill_tree damageTree;

    //health tree
    skill_tree_branch healthRoot;
    skill_tree_branch healthIncreaseBase, healthIncreaseI, healthIncreaseII, healthIncreaseIII, healthIncreaseIV, healthIncreaseV;
    skill_tree_branch healthRecoveryBase, healthRecoveryI, healthRecoveryII, healthRecoveryIII, healthRecoveryIV;
    skill_tree_branch healthRegenBase, healthRegenI;
    skill_tree healthTree;

    //energyree
    skill_tree_branch energyRoot;
    skill_tree_branch energyAttackBase, energyAttackI, energyAttackII;
    skill_tree_branch energyRunBase, energyRunI, energyRunII;
    skill_tree_branch energyWalkSpeedBase, energyWalkSpeedI, energyWalkSpeedII;
    skill_tree_branch energyRunSpeedBase, energyRunSpeedI, energyRunSpeedII;
    skill_tree_branch energyRegenBase, energyRegenI, energyRegenII;

    skill_tree energyTree;

    //list of all trees
    skill_tree[] trees;


    // Start is called before the first frame update
    void Start()
    {
        //damage tree
        damageRoot = new skill_tree_branch();

        //constructor is ("tag", level, requirements[], modifier)
        damageBuffBase = new skill_tree_branch("DamageBuff", 1f); //this tag is a multiplier to players damage
        damageBuffI = new skill_tree_branch("DamageBuff", 1, new skill_tree_branch[2] { damageRoot, damageBuffBase }, 1.25f);
        damageBuffII = new skill_tree_branch("DamageBuff", 2, new skill_tree_branch[1] { damageBuffI }, 1.5f);
        damageBuffIII = new skill_tree_branch("DamageBuff", 3, new skill_tree_branch[1] { damageBuffII }, 1.75f);
        damageBuffIV = new skill_tree_branch("DamageBuff", 4, new skill_tree_branch[1] { damageBuffIII }, 2f);

        damageCritBuffBase = new skill_tree_branch("DamageCritBuff", 2f); //this tag is a multiplier to damage dealt on critical hit
        damageCritBuffI = new skill_tree_branch("DamageCritBuff", 1, new skill_tree_branch[2] { damageCritBuffBase, damageBuffIV }, 3f);
        damageCritBuffII = new skill_tree_branch("DamageCritBuff", 2, new skill_tree_branch[1] { damageCritBuffI }, 4f);

        damageCritChanceBase = new skill_tree_branch("DamageCritChance", 0f); //this tag is an additive percentage to crit chance
        damageCritChanceI = new skill_tree_branch("DamageCritChance", 1, new skill_tree_branch[2] { damageCritChanceBase, damageBuffIV }, 15f);
        damageCritChanceII = new skill_tree_branch("DamageCritChance", 2, new skill_tree_branch[1] { damageCritChanceI }, 30f);

        damageCritStunBase = new skill_tree_branch("DamageCritStun", 0f); //this tag is the time an enemy is stunned for when hit by a critical hit
        damageCritStunI = new skill_tree_branch("DamageCritStun", 1, new skill_tree_branch[3] { damageCritStunBase, damageCritBuffII, damageCritChanceII }, 1f);
        damageCritStunII = new skill_tree_branch("DamageCritStun", 2, new skill_tree_branch[1] { damageCritStunI }, 2f);

        skill_tree_branch[] damageBranches = new skill_tree_branch[16]
            { 
            damageRoot, 
            damageBuffBase, damageBuffI, damageBuffII, damageBuffIII, damageBuffIV,
            damageCritBuffBase, damageCritBuffI, damageCritBuffII, damageBuffIII,
            damageCritChanceBase, damageCritChanceI, damageCritChanceII,
            damageCritStunBase, damageCritStunI, damageCritStunII
            };

        damageTree = new skill_tree("Damage", damageBranches);


        //health tree
        healthRoot = new skill_tree_branch();

        //constructor is ("tag", level, requirements[], modifier)
        healthIncreaseBase = new skill_tree_branch("HealthIncrease", 100f); //this tag is the players max health
        healthIncreaseI = new skill_tree_branch("HealthIncrease", 1, new skill_tree_branch[2] { healthRoot, healthIncreaseBase }, 120f);
        healthIncreaseII = new skill_tree_branch("HealthIncrease", 2, new skill_tree_branch[1] { healthIncreaseI }, 140f);
        healthIncreaseIII = new skill_tree_branch("HealthIncrease", 3, new skill_tree_branch[1] { healthIncreaseII }, 160f);
        healthIncreaseIV = new skill_tree_branch("HealthIncrease", 4, new skill_tree_branch[1] { healthIncreaseIII }, 180f);
        healthIncreaseV = new skill_tree_branch("HealthIncrease", 5, new skill_tree_branch[1] { healthIncreaseIV }, 200f);

        healthRecoveryBase = new skill_tree_branch("HealthRecovery", 1f); //this tag is a multiplier to the effects of health potions
        healthRecoveryI = new skill_tree_branch("HealthRecovery", 1, new skill_tree_branch[2] { healthRecoveryBase, healthIncreaseI }, 1.25f);
        healthRecoveryII = new skill_tree_branch("HealthRecovery", 2, new skill_tree_branch[1] { healthRecoveryI }, 1.5f);
        healthRecoveryIII = new skill_tree_branch("HealthRecovery", 3, new skill_tree_branch[1] { healthRecoveryII }, 1.75f);
        healthRecoveryIV = new skill_tree_branch("HealthRecovery", 4, new skill_tree_branch[1] { healthRecoveryIII }, 2f);

        healthRegenBase = new skill_tree_branch("HealthRegen", 0f); //this tag is the amount of health regen
        healthRegenI = new skill_tree_branch("HealthRegen", 1, new skill_tree_branch[3] { healthRegenBase, healthIncreaseV, healthRecoveryIV }, 1f);


        skill_tree_branch[] healthBranches = new skill_tree_branch[14]
            {
            healthRoot,
            healthIncreaseBase, healthIncreaseI, healthIncreaseII, healthIncreaseIII, healthIncreaseIV, healthIncreaseV,
            healthRecoveryBase, healthRecoveryI, healthRecoveryII, healthRecoveryIII, healthRecoveryIV,
            healthRegenBase, healthRegenI
            };

        healthTree = new skill_tree("Health", healthBranches);


        //energy tree
        energyRoot = new skill_tree_branch();

        //constructor is ("tag", level, requirements[], modifier)
        energyAttackBase = new skill_tree_branch("AttackEnergy", 1f); //this tag is a multiplier to energy consumption of attacking
        energyAttackI = new skill_tree_branch("AttackEnergy", 1, new skill_tree_branch[2] { energyRoot, energyAttackBase }, .9f);
        energyAttackII = new skill_tree_branch("AttackEnergy", 2, new skill_tree_branch[1] { energyAttackI }, .8f);

        energyRunBase = new skill_tree_branch("RunEnergy", 1f); //this tag is a multiplier to energy consumption of running
        energyRunI = new skill_tree_branch("RunEnergy", 1, new skill_tree_branch[2] { energyRoot, energyRunBase }, .9f);
        energyRunII = new skill_tree_branch("RunEnergy", 2, new skill_tree_branch[1] { energyRunI }, .8f);

        energyWalkSpeedBase = new skill_tree_branch("WalkSpeed", 1f); //this tag is a multiplier to walk speed
        energyWalkSpeedI = new skill_tree_branch("WalkSpeed", 1, new skill_tree_branch[3] { energyRoot, energyWalkSpeedBase, energyRunI }, 1.25f);
        energyWalkSpeedII = new skill_tree_branch("WalkSpeed", 2, new skill_tree_branch[1] { energyWalkSpeedI }, 1.5f);

        energyRunSpeedBase = new skill_tree_branch("RunSpeed", 1f); //this tag is a multiplier to run speed
        energyRunSpeedI = new skill_tree_branch("RunSpeed", 1, new skill_tree_branch[3] { energyRoot, energyRunSpeedBase, energyRunI }, 1.25f);
        energyRunSpeedII = new skill_tree_branch("RunSpeed", 2, new skill_tree_branch[1] { energyRunSpeedI }, 1.5f);

        energyRegenBase = new skill_tree_branch("EnergyRegen", 1f); //this tag is a multiplier to energy regen rate
        energyRegenI = new skill_tree_branch("EnergyRegen", 1, new skill_tree_branch[4] { energyRoot, energyRegenBase, energyRunII, energyAttackII }, 1.25f);
        energyRegenII = new skill_tree_branch("EnergyRegen", 2, new skill_tree_branch[1] { energyRegenI }, 1.5f);


        skill_tree_branch[] energyBranches = new skill_tree_branch[16]
            {
            energyRoot,
            energyAttackBase, energyAttackI, energyAttackII,
            energyRunBase, energyRunI, energyRunII,
            energyWalkSpeedBase, energyWalkSpeedI, energyWalkSpeedII,
            energyRunSpeedBase, energyRunSpeedI, energyRunSpeedII,
            energyRegenBase, energyRegenI, energyRegenII
            };

        energyTree = new skill_tree("Energy", energyBranches);


        //list of all trees
        trees = new skill_tree[3] { damageTree, healthTree, energyTree };
    }

    public skill_tree GetTreeWithTag(string tag)
    {
        for (int i = 0; i < trees.Length; i++)
        {
            if (trees[i].GetTag() == tag)
            {
                return trees[i];
            }
        }

        return null; //should not happen. if does, you searched for a non existant branch
    }
}
