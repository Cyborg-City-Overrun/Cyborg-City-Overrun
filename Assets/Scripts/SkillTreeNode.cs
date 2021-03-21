using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeNode
{
    private string name;
    private float[] skillIncrease;
    private float totalSkill;
    private int curTier;

    public SkillTreeNode()
    {
        new SkillTreeNode("Null", null);
    }

    public SkillTreeNode(string name, float[] increase)
    {
        this.name = name;
        this.skillIncrease = increase;
        curTier = 0;
        totalSkill = 0;
    }
    
    public void incraseTier()
    {
        if(!isMaxTier())
        {
            totalSkill += skillIncrease[curTier];
            curTier++;
        }
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
