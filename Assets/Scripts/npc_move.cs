using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_move : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private Vector2 myMovement = Vector2.zero;

    private float myTimer = 0;
    private float myChangeTime = 0;

    public float mySpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        myTimer += Time.deltaTime;
        if (myTimer >= myChangeTime)
        {
            print("changing direction");
            myTimer = 0;
            myChangeTime = Random.Range(1f, 3f);
            ChangeDirection();
            print("New direction: (" + myMovement.x + ", " + myMovement.y + ")");
        }

        myRigidBody.MovePosition(myRigidBody.position + myMovement * mySpeed * Time.fixedDeltaTime);

    }

    private void ChangeDirection()
    {
        float moveX;
        float moveY;
        float rand = Random.Range(0f, 1f);
        float randX = 1 - rand;
        float randY = 0 + rand;

        int xSign = Random.Range(0, 2); //returns 0 or 1
        if (xSign == 0)
        {
            randX *= -1;
        }
        int ySign = Random.Range(0, 2); //returns 0 or 1
        if (ySign == 0)
        {
            randY *= -1;
        }

        moveX = 0 - randX;
        moveY = 0 + randY;
        myMovement.x = moveX;
        myMovement.y = moveY;
    }
}
