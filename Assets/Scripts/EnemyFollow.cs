﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Animator myAnim;

    private float mySpeed = 8f;
    private float myPower = 5f;

    private Rigidbody2D myRigidBody;

    private GameObject myTarget;
    private Transform myTargetPos;

    private float myFollowRange = 3f;
    private float myAttackRange = .75f;

    private float myAttackCooldown = .3f;
    private float myTimeSinceAttack;
    

    // Start is called before the first frame update
    private void Start()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myTarget = GameObject.FindGameObjectWithTag("Player");
        myTargetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        myRigidBody.velocity = Vector2.zero;
        CheckAttackAndMove();
    }

    private void CheckAttackAndMove()
    {
        myTimeSinceAttack += Time.deltaTime;
        if (Vector2.Distance(transform.position, myTargetPos.position) < myAttackRange)
        {
            myAnim.SetBool("isMoving", false);

            if (myTimeSinceAttack >= myAttackCooldown)
            {
                myTimeSinceAttack = 0;
                Attack();
            }
        }
        else
        {
            CheckMove();
        }
    }

    private void CheckMove()
    {
        if (Vector2.Distance(transform.position, myTargetPos.position) < myFollowRange)
        {
            Move();
        }
        else
        {
            myAnim.SetBool("isMoving", false);
        }
    }
    private void Move()
    {
        myAnim.SetBool("isMoving", true);
        myRigidBody.MovePosition(Vector2.MoveTowards(transform.position, myTargetPos.position, mySpeed * Time.deltaTime));
        //transform.position = Vector2.MoveTowards(transform.position, myTarget.position, mySpeed * Time.deltaTime);
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        float delta_x = myRigidBody.position.x - myTargetPos.position.x;
        float delta_y = myRigidBody.position.y - myTargetPos.position.y;
        
        if (Mathf.Abs(delta_x) > Mathf.Abs(delta_y))
        {
            myAnim.SetFloat("moveY", 0);
            if (delta_x < 0)
            {
                myAnim.SetFloat("moveX", 1);
            }
            else
            {
                myAnim.SetFloat("moveX", -1);
            }
        }
        else
        {
            myAnim.SetFloat("moveX", 0);
            if (delta_y < 0)
            {
                myAnim.SetFloat("moveY", 1);
            }
            else
            {
                myAnim.SetFloat("moveY", -1);
            }
        }
    }


    private void Attack()
    {
        myTarget.GetComponent<player_control>().TakeDamage(myPower);
    }
}