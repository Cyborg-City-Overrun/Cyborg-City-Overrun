using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    // Variables
    private Rigidbody2D myRigidBody;

    private Animator myAnim;

    private float mySpeed = 3f;

    private Vector2 myMovement = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myMovement.x = Input.GetAxisRaw("Horizontal");
        myMovement.y = Input.GetAxisRaw("Vertical");
        UpdateAnimation();
        Move();
    }

    void UpdateAnimation()
    {
        if (myMovement != Vector2.zero)
        {
            myAnim.SetFloat("moveX", myMovement.x);
            myAnim.SetFloat("moveY", myMovement.y);
            myAnim.SetBool("moving", true);
        }
        else
        {
            myAnim.SetBool("moving", false);
        }
    }

    void Move()
    {
        myRigidBody.MovePosition(myRigidBody.position + myMovement * mySpeed * Time.fixedDeltaTime);
    }
}
