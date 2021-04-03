using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimlessNPC : MonoBehaviour
{

    public int position; //0 is down, 1 is up, 2 is left, 3 is right!
    public float speeed = 4f;
    private Animator myAnim;
    private Rigidbody2D myRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        position = 0;
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myAnim.SetBool("isMoving", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void changeDirection()
    {
        int choose;
        position = (int)Random.value*3;
        choose = (int)Random.value*1;
        if(choose == 0)
        {
            idleForABit();
        }
        else
        {
            itsWalkingTimeee();
        }
        changeDirection();

    }

    IEnumerator idleForABit()
    {
        myAnim.SetBool("isMoving", false);
        myRigidBody.velocity = Vector2.zero;
        yield return new WaitForSecondsRealtime(Random.value * 5);
    }

    private void itsWalkingTimeee()
    {
        myAnim.SetBool("isMoving", true);
        int howfar;
        howfar = (int)Random.value * 10;



        //myRigidBody.MovePosition(Vector2.MoveTowards());
        //Time.fixedDeltaTime

    }
}
