using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_shootFire : MonoBehaviour
{

    private Animator myAnim;
    public GameObject funnyFire;
    private bool fired = false;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (fired)
        {
            if (!myAnim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                fired = false;
            }
        }
        else
        {
            if(myAnim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {

                if (myAnim.GetFloat("moveX") == 1)
                {
                    Instantiate(funnyFire, new Vector3(transform.GetChild(3).position.x, transform.GetChild(3).position.y, -1), Quaternion.identity);

                }
                else if (myAnim.GetFloat("moveX") == -1)
                {
                    Instantiate(funnyFire, new Vector3(transform.GetChild(3).position.x, transform.GetChild(3).position.y, -1), Quaternion.identity);

                }
                else if (myAnim.GetFloat("moveY") == 1)
                {
                    Instantiate(funnyFire, new Vector3(transform.GetChild(3).position.x, transform.GetChild(3).position.y, -1), Quaternion.identity);

                }
                else if (myAnim.GetFloat("moveY") == -1)
                {
                    Instantiate(funnyFire, new Vector3(transform.GetChild(3).position.x, transform.GetChild(3).position.y, -1), Quaternion.identity);

                }



                fired = true;
            }
        }
    }
}

/*
while (myAnim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
{
    if (!fired)
    {
        fired = true;
        if (myAnim.GetFloat("moveX") == 1)
        {
            GameObject ff = Instantiate(funnyFire.gameObject, new Vector3(transform.GetChild(3).position.x, transform.GetChild(3).position.y, -1), Quaternion.identity);
            ff.GetComponent<Animator>().Play("Right");
        }
        else if (myAnim.GetFloat("moveX") == -1)
        {
            GameObject ff = Instantiate(funnyFire.gameObject, new Vector3(transform.GetChild(3).position.x, transform.GetChild(3).position.y, -1), Quaternion.identity);
            ff.GetComponent<Animator>().Play("Left");
        }
        else if (myAnim.GetFloat("moveY") == 1)
        {
            GameObject ff = Instantiate(funnyFire.gameObject, new Vector3(transform.GetChild(3).position.x, transform.GetChild(3).position.y, -1), Quaternion.identity);
            ff.GetComponent<Animator>().Play("Up");
        }
        else if (myAnim.GetFloat("moveY") == -1)
        {
            GameObject ff = Instantiate(funnyFire.gameObject, new Vector3(transform.GetChild(3).position.x, transform.GetChild(3).position.y, -1), Quaternion.identity);
            ff.GetComponent<Animator>().Play("Down");
        }
    }
}
fired = false;
*/