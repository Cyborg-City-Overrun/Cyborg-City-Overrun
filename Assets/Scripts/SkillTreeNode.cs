using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeNode
{
    private int id;
    private float[] skillIncrease;
    private float totalSkill;
    private int curTier;

    public SkillTreeNode()
    {
        new SkillTreeNode(-1, null);
    }

    public SkillTreeNode(int id, float[] increase)
    {
        this.id = id;
        this.skillIncrease = increase;
        curTier = 0;
        totalSkill = 0;
    }
    
    public bool incraseTier()
    {
        if(!isMaxTier())
        {
            totalSkill += skillIncrease[curTier];
            curTier++;
            return true;
        }
        return false;
    }

    public float getTotalSkill()
    {
        return totalSkill;
    }

    public bool isMaxTier()
    {
        if(curTier==skillIncrease.Length)
        {
            return true;
        }
        return false;
    }

}
