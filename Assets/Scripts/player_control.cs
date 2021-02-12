using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    // Variables
    private Rigidbody2D myRigidBody;

    private Animator myAnim;

    private float mySpeed = 4f;

    private Vector2 myMovement = Vector2.zero;

    public GameObject AttackArea;

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
        determineArea();
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

        if(Input.GetKey(KeyCode.Z))
        {
            AttackArea.SetActive(true);
            myAnim.SetBool("isAttacking", true);
        }

        else
        {
            AttackArea.SetActive(false);
            myAnim.SetBool("isAttacking", false);
        }
    }

    void Move()
    {
        myRigidBody.MovePosition(myRigidBody.position + myMovement * mySpeed * Time.fixedDeltaTime);
    }

    void determineArea()
    {

        if (myMovement.x == 0f && myMovement.y == 1f)
        {
            AttackArea.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
        }

        else if (myMovement.x == 0f && myMovement.y == -1f)
        {
            AttackArea.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }

        else if (myMovement.x == 1f && myMovement.y == 0f)
        {
            AttackArea.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
        }

        else if (myMovement.x == -1f && myMovement.y == 0f)
        {
            AttackArea.transform.localEulerAngles = new Vector3(0f, 0f, 270f);
        }
    }
}
