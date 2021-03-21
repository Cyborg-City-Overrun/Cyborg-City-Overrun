using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree
{
    private string treeName;
    private SkillTreeNode[] nodes;

    public SkillTree()
    {
        new SkillTree("Null",null);
    }

    public SkillTree(string treeName, SkillTreeNode[] nodes)
    {
        this.treeName = treeName;
        this.nodes = new SkillTreeNode[nodes.Length];
        this.nodes = nodes;
    }

    public void increaseNode(int newPos)
    {
        nodes[newPos].incraseTier();
    }

    
}