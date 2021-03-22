using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree
{
    private int id;
    private SkillTreeNode[] nodes;

    public SkillTree()
    {
        new SkillTree(-1, null);
    }

    public SkillTree(int id, SkillTreeNode[] nodes)
    {
        this.id = id;
        this.nodes = new SkillTreeNode[nodes.Length];
        this.nodes = nodes;
    }

    public void increaseNode(int node)
    {
        nodes[node].incraseTier();
    }

    public SkillTreeNode getNode(int id)
    {
        return nodes[id];
    }

    
}