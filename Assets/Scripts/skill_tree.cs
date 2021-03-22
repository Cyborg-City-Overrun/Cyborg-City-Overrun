using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_tree
{
    private string tag;
    private skill_tree_branch[] branches;
    
    public skill_tree(string t, skill_tree_branch[] b)
    {
        tag = t;

        branches = new skill_tree_branch[b.Length];
        branches = b;
    }

    public string GetTag()
    {
        return tag;
    }

    public skill_tree_branch GetActiveBranchWithTag(string tag)
    {
        for (int i = 0; i < branches.Length; i++)
        {
            if (branches[i].GetTag() == tag && branches[i].IsActive())
            {
                return branches[i];
            }
        }

        return null; //this should not be reached. if it is, that means there was no branch with the ggiven tag
    }
    public skill_tree_branch GetBranchWithTagAndLevel(string tag, int level)
    {
        for (int i = 0; i < branches.Length; i++)
        {
            if (branches[i].GetTag() == tag && branches[i].GetLevel() == level)
            {
                return branches[i];
            }
        }

        return null; //this should not be reached. if it is, that means there was no branch with the given tag or level
    }
}
