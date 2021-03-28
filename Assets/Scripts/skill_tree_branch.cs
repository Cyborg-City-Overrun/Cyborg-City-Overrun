using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_tree_branch
{
    private string tag; //tag is used to identify if things are of the same perk type
                        //there will only be one "active" branch for each tag
                        //ie damage I and damage II both have "Damage" tag and unlocking II will deactivate I

    private int level; //what level upgrade is this, used for aquiring upgrades

    private skill_tree_branch[] requirements;
    
    private float modifier;

    private bool isUnlocked;
    private bool isActive; //isActive is used for perks that have sevral tiers so only the top level tier is active

    public skill_tree_branch() //root constructor
    {
        tag = "Root";

        level = -1;

        requirements = null;
        
        modifier = 0;
        
        isUnlocked = true;
        isActive = true;
    }

    public skill_tree_branch(string t, float mod) //base constructor
    {
        tag = t;

        level = 0;

        requirements = null;
        
        modifier = mod;
        
        isUnlocked = true;
        isActive = true;
    }

    public skill_tree_branch(string t, int l, skill_tree_branch[] req, float mod) //regular branch constructor
    {
        tag = t;

        level = l;

        requirements = new skill_tree_branch[req.Length];
        requirements = req;

        modifier = mod;

        isUnlocked = false;
        isActive = false;
    }

    public string GetTag()
    {
        return tag;
    }

    public int GetLevel()
    {
        return level;
    }
    public float GetModifier()
    {
        return modifier;
    }

    public bool IsUnlocked()
    {
        return isUnlocked;
    }

    public bool IsUnlockable()
    {
        if (IsUnlocked()) //if already unlocked, can not be unlocked again
        {
            return false;
        }

        for (int i = 0; i < requirements.Length; i++) //if any of the requirements are still locked, then this is unlockable
        {
            if (!requirements[i].IsUnlocked())
            {
                return false;
            }
        }
        return true;
    }

    public void Unlock()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (IsUnlockable() && player.GetComponent<player_control>().UseSkillPoint())
        {
            isUnlocked = true;
            isActive = true;
            for (int i = 0; i < requirements.Length; i++)
            {
                if (requirements[i].GetTag() == GetTag())
                {
                    requirements[i].Deactivate();
                }
            }
        }
    }

    public void Deactivate()
    {
        isActive = false;
    }

    public bool IsActive()
    {
        return isActive;
    }
}
