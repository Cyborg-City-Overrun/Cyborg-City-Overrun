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

    public GameObject[] HealthIncreaseButtons;
    public GameObject[] HealthRecoveryButtons;
    public GameObject[] HealthRegenButtons;

    public GameObject[] EnergyAttackButtons;
    public GameObject[] EnergyRunButtons;
    public GameObject[] EnergyWalkSpeedButtons;
    public GameObject[] EnergyRunSpeedButtons;
    public GameObject[] EnergyRegenButtons;


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
        UpdateHealth();
        UpdateEnergy();
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

    //damage
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

    //health
    public void UpdateHealth()
    {
        UpdateHealthIncrease();
        UpdateHealthRecovery();
        UpdateHealthRegen();
    }

    public void UpdateHealthIncrease()
    {
        UpdateButtons(HealthIncreaseButtons, "Health", "HealthIncrease");
    }
    public void UpdateHealthRecovery()
    {
        UpdateButtons(HealthRecoveryButtons, "Health", "HealthRecovery");
    }
    public void UpdateHealthRegen()
    {
        UpdateButtons(HealthRegenButtons, "Health", "HealthRegen");
    }

    //energy
    public void UpdateEnergy()
    {
        UpdateEnergyAttack();
        UpdateEnergyRun();
        UpdateWalkSpeed();
        UpdateRunSpeed();
        UpdateEnergyRegen();
    }

    public void UpdateEnergyAttack()
    {
        UpdateButtons(EnergyAttackButtons, "Energy", "AttackEnergy");
    }
    public void UpdateEnergyRun()
    {
        UpdateButtons(EnergyRunButtons, "Energy", "RunEnergy");
    }
    public void UpdateWalkSpeed()
    {
        UpdateButtons(EnergyWalkSpeedButtons, "Energy", "WalkSpeed");
    }
    public void UpdateRunSpeed()
    {
        UpdateButtons(EnergyRunSpeedButtons, "Energy", "RunSpeed");
    }
    public void UpdateEnergyRegen()
    {
        UpdateButtons(EnergyRegenButtons, "Energy", "EnergyRegen");
    }
}
