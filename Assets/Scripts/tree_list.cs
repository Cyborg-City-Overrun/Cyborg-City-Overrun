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

    skill_tree_branch damageBuffBase;
    skill_tree_branch damageBuffI;
    skill_tree_branch damageBuffII;
    skill_tree_branch damageBuffIII;
    skill_tree_branch damageBuffIV;

    skill_tree_branch damageCritBuffBase; 
    skill_tree_branch damageCritBuffI;

    skill_tree damageTree;

    //other trees...


    //list of all trees
    skill_tree[] trees;


    // Start is called before the first frame update
    void Start()
    {
        //damage tree
        damageRoot = new skill_tree_branch();

        //constructor is ("tag", level, requirements[], modifier)
        damageBuffBase = new skill_tree_branch("DamageBuff", 1f); //this tag is a multiplier to players damage
        damageBuffI = new skill_tree_branch("DamageBuff", 1, new skill_tree_branch[2] { damageRoot, damageBuffBase }, 1.5f);
        damageBuffII = new skill_tree_branch("DamageBuff", 2, new skill_tree_branch[1] { damageBuffI }, 2f);
        damageBuffIII = new skill_tree_branch("DamageBuff", 3, new skill_tree_branch[1] { damageBuffII }, 2.5f);
        damageBuffIV = new skill_tree_branch("DamageBuff", 4, new skill_tree_branch[1] { damageBuffIII }, 3f);

        damageCritBuffBase = new skill_tree_branch("DamageCritBuff", 2f); //this tag is a multiplier to damage dealt on critical hit
        damageCritBuffI = new skill_tree_branch("DamageCritBuff", 1, new skill_tree_branch[1] { damageRoot }, 2f);

        skill_tree_branch[] damageBranches = new skill_tree_branch[8]
            { 
            damageRoot, 
            damageBuffBase, damageBuffI, damageBuffII, damageBuffIII, damageBuffIV, 
            damageCritBuffBase, damageCritBuffI
            };

        damageTree = new skill_tree("Damage", damageBranches);


        //other trees...

        //list of all trees
        trees = new skill_tree[1] { damageTree };
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
