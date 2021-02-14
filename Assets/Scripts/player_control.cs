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

    private float myAttackCooldown = 1f;
    private float timeSinceAttack = 0;

    public Transform camTF;

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
        Move();
        CheckAttack();

        camTF.position = new Vector3(this.transform.position.x, this.transform.position.y,-10f);
    }

    void Move()
    {
        if (myMovement != Vector2.zero)
        {
            myRigidBody.MovePosition(myRigidBody.position + myMovement * mySpeed * Time.fixedDeltaTime);
            myAnim.SetFloat("moveX", myMovement.x);
            myAnim.SetFloat("moveY", myMovement.y);
            myAnim.SetBool("moving", true);
        }
        else
        {
            myAnim.SetBool("moving", false);
        }
    }


    void CheckAttack()
    {
        timeSinceAttack += Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.Space) && timeSinceAttack >= myAttackCooldown)
        {
            myAnim.SetBool("isAttacking", true);
            timeSinceAttack = 0;
        }
        else
        {
            myAnim.SetBool("isAttacking", false);

        }
    }
}
