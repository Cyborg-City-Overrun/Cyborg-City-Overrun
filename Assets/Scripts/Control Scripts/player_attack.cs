using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    private GameObject myPlayer;
    private bool critical = false;

    private void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            hit.GetComponent<enemy_control>().TakeDamage(DamageAmount());
            if (critical == true)
            {
                critical = false;
                hit.GetComponent<enemy_control>().Stun(myPlayer.GetComponent<tree_list>().GetTreeWithTag("Damage").GetActiveBranchWithTag("DamageCritStun").GetModifier());
            }
        }
    }

    private float DamageAmount()
    {
        float baseDamage = myPlayer.GetComponent<player_control>().GetSword().GetBaseDamageWithModifier();
        float treeMultiplier = myPlayer.GetComponent<tree_list>().GetTreeWithTag("Damage").GetActiveBranchWithTag("DamageBuff").GetModifier();

        float damage = baseDamage * treeMultiplier;
        damage *= Random.Range(.75f, 1.25f); //variance

        float critChanceSword = myPlayer.GetComponent<player_control>().GetSword().GetCritChance();
        float critChanceTree = myPlayer.GetComponent<tree_list>().GetTreeWithTag("Damage").GetActiveBranchWithTag("DamageCritChance").GetModifier();
        float critChance = critChanceSword + critChanceTree;

        if (Random.Range(0f, 100f) <= critChance) //chance to be critical is critChance as a percentage
        {
            print("Critical Hit");
            critical = true;
            damage *= myPlayer.GetComponent<tree_list>().GetTreeWithTag("Damage").GetActiveBranchWithTag("DamageCritBuff").GetModifier();
        }

        return damage;
    }
}
