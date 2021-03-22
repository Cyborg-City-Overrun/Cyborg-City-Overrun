using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_trees : MonoBehaviour
{
    public GameObject[] DamageBuffButtons;

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

    private void UpdateDisplay()
    {
        for (int i = 0; i < DamageBuffButtons.Length; i++)
        {
            Color color = DamageBuffButtons[i].transform.GetComponent<Image>().color;
            if (i < player.GetComponent<tree_list>().GetTreeWithTag("Damage").GetActiveBranchWithTag("DamageBuff").GetLevel())
            {
                DamageBuffButtons[i].transform.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 1);
            }
            else if (i == player.GetComponent<tree_list>().GetTreeWithTag("Damage").GetActiveBranchWithTag("DamageBuff").GetLevel())
            {
                DamageBuffButtons[i].transform.GetComponent<Image>().color = new Color(color.r, color.g, color.b, .5f);
            }
            else 
            {
                DamageBuffButtons[i].transform.GetComponent<Image>().color = new Color(color.r, color.g, color.b, .2f);
            }
        }
    }
}
