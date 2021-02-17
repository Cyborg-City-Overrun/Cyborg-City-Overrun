using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_control : MonoBehaviour
{
    private Animator myAnim;

    public float mySpeed = 8f;
    public float myPower = 5f;

    private Rigidbody2D myRigidBody;

    private GameObject myTarget;
    private Transform myTargetPos;

    public float myFollowRange = 3f;
    public float myAttackRange = .75f;

    public float myAttackCooldown = .4f;
    private float myTimeSinceAttack;

    public float myMaxHealth = 20f;
    private float myHealth;
    //private SpriteRenderer renders;
    //private float colorTimer = 0;

    public HealthBar myHealthBar;

    public int deathRewardMin;
    public int deathRewardMax;


    private void Start()
    {
        //render = GetComponent<SpriteRenderer>();
        myHealthBar.SetMaxHealth(myMaxHealth);
        myHealth = myMaxHealth;
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myTarget = GameObject.FindGameObjectWithTag("Player");
        myTargetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myAnim = GetComponent<Animator>();
    }
    
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

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Attack")
        {
            takeDamage(4);

            if (myHealth <= 0)
            {
                myTarget.GetComponent<player_control>().Transaction(Random.Range(deathRewardMin, deathRewardMax + 1));
                Destroy(gameObject);
            }
        }
    }

    private void takeDamage(float damage)
    {
        myHealth -= damage;

        //render.color = new Color(1, render.color.b - .25f, render.color.g - .25f);

        myHealthBar.SetHealth(myHealth);
    }
}
