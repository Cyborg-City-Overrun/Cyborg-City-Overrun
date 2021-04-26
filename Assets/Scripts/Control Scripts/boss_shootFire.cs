using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_shootFire : MonoBehaviour
{

    public GameObject boss;
    public GameObject funnyFire;
    private bool flaming = false;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void startFlame()
    {
        if (flaming == false)
        {
            flaming = true;
            while (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attack") == true && boss.GetComponent<Animator>().GetFloat("moveX") == 1)
                {
                    Instantiate(funnyFire.gameObject, new Vector3(boss.GetComponent<GameObject>().transform.GetChild(3).position.x, boss.GetComponent<GameObject>().transform.GetChild(3).position.y, -1), Quaternion.identity);
                    funnyFire.GetComponent<Animator>().Play("Right");
                }
                else if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attack") == true && boss.GetComponent<Animator>().GetFloat("moveX") == -1)
                {
                    Instantiate(funnyFire.gameObject, new Vector3(boss.GetComponent<GameObject>().transform.GetChild(3).position.x, boss.GetComponent<GameObject>().transform.GetChild(3).position.y, -1), Quaternion.identity);
                    funnyFire.GetComponent<Animator>().Play("Left");
                }
                else if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attack") == true && boss.GetComponent<Animator>().GetFloat("moveY") == 1)
                {
                    Instantiate(funnyFire.gameObject, new Vector3(boss.GetComponent<GameObject>().transform.GetChild(3).position.x, boss.GetComponent<GameObject>().transform.GetChild(3).position.y, -1), Quaternion.identity);
                    funnyFire.GetComponent<Animator>().Play("Up");
                }
                else if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attack") == true && boss.GetComponent<Animator>().GetFloat("moveY") == -1)
                {
                    Instantiate(funnyFire.gameObject, new Vector3(boss.GetComponent<GameObject>().transform.GetChild(3).position.x, boss.GetComponent<GameObject>().transform.GetChild(3).position.y, -1), Quaternion.identity);
                    funnyFire.GetComponent<Animator>().Play("Down");
                }
                else
                {

                }
            }
            flaming = false;
        }
        else
        {

        }
    }
}
