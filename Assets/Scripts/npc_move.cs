using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_move : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private Vector2 myMovement = Vector2.zero;

    public BoxCollider2D collider;

    private float myTimer = 0;
    private float myChangeTime = 0;

    public float mySpeed = 1f;


    private Animator myAnim;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        myAnim = GetComponent<Animator>();
        myAnim.SetBool("isMoving", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRigidBody.velocity = Vector2.zero;
        Move();
    }

    private void Move()
    {
        myTimer += Time.deltaTime;
        if (myTimer >= myChangeTime)
        {
            myTimer = 0;
            myChangeTime = Random.Range(1f, 3f);
            ChangeDirection();
        }

        myAnim.SetFloat("moveX", myMovement.x);
        myAnim.SetFloat("moveY", myMovement.y);

        myRigidBody.MovePosition(myRigidBody.position + myMovement * mySpeed * Time.fixedDeltaTime);
    }

    private void ChangeDirection()
    {

        int move = Random.Range(-1, 2); //-1, 0, or 1


        int plane = Random.Range(0, 2); //0 or 1 (horizontal or vertical)

        if (plane == 0)
        {
            myMovement.x = move;
            myMovement.y = 0;
        }
        else
        {
            myMovement.y = move;
            myMovement.x = 0;
        }

        if (move == 0)
        {
            myAnim.SetBool("isMoving", false);
        }
        else
        {
            myAnim.SetBool("isMoving", true);
        }

        myRigidBody.MovePosition(myRigidBody.position + myMovement * mySpeed * Time.fixedDeltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myMovement.x *= -1;
        myMovement.y *= -1;
    }
}
