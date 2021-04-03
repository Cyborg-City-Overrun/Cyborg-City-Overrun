using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{ 
    private SkillTree damageTree;
    private SkillTreeNode damageIncreasePerk;

    private SkillTree[] trees;


    // Start is called before the first frame update
    void Start()
    {
        damageIncreasePerk = new SkillTreeNode(0, new float[] { .2f, .2f });
        damageTree = new SkillTree(0, new SkillTreeNode[] { damageIncreasePerk });



        trees = new SkillTree[1];

        trees[0] = damageTree;

    }

    public SkillTree GetTree(int id)
    {
        return trees[id];
    }
}
