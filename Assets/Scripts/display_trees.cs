using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_trees : MonoBehaviour
{
    public GameObject[] DamageBuffButtons;
    public GameObject[] DamageCritBuffButtons;
    public GameObject[] DamageCritChanceButtons;
    public GameObject[] DamageCritStunButtons;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        UpdateDamage();
    }

    private void UpdateButtons(GameObject[] list, string tree_tag, string branch_tag)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Color color = list[i].transform.GetComponent<Image>().color;
            if (i < player.GetComponent<tree_list>().GetTreeWithTag(tree_tag).GetActiveBranchWithTag(branch_tag).GetLevel())
            {
                list[i].transform.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 1);
            }
            else if (i == player.GetComponent<tree_list>().GetTreeWithTag(tree_tag).GetActiveBranchWithTag(branch_tag).GetLevel() && player.GetComponent<tree_list>().GetTreeWithTag(tree_tag).GetNextBranchWithTag(branch_tag).IsUnlockable())
            {
                list[i].transform.GetComponent<Image>().color = new Color(color.r, color.g, color.b, .4f);
            }
            else 
            {
                list[i].transform.GetComponent<Image>().color = new Color(color.r, color.g, color.b, .15f);
            }
        }
    }

    public void UpdateDamage()
    {
        UpdateDamageBuff();
        UpdateDamageCritBuff();
        UpdateDamageCritChance();
        UpdateDamageCritStun();
    }

    public void UpdateDamageBuff()
    {
        UpdateButtons(DamageBuffButtons, "Damage", "DamageBuff");
    }
    public void UpdateDamageCritBuff()
    {
        UpdateButtons(DamageCritBuffButtons, "Damage", "DamageCritBuff");
    }
    public void UpdateDamageCritChance()
    {
        UpdateButtons(DamageCritChanceButtons, "Damage", "DamageCritChance");
    }
    public void UpdateDamageCritStun()
    {
        UpdateButtons(DamageCritStunButtons, "Damage", "DamageCritStun");
    }
}
