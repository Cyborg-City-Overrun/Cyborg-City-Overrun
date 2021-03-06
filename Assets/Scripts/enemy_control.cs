using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_control : MonoBehaviour
{
    private Animator myAnim;

    public float mySpeed = 8f;
    public float myPower = 2f;
    public item[] drops;

    private Rigidbody2D myRigidBody;

    private GameObject myTarget;
    private Transform myTargetPos;

    public float myFollowRange = 3f;
    public float myAttackRange = .75f;

    public float myAttackCooldown = .4f;
    private float myTimeSinceAttack;

    public float myMaxHealth = 20f;
    private float myHealth;

    public HealthBar myHealthBar;

    public int deathRewardMin;
    public int deathRewardMax;

    public GameObject floatingDamage;

    public GameObject hitBox;


    private void Start()
    {
        myHealthBar.SetMaxHealth(myMaxHealth);
        myHealth = myMaxHealth;
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myTarget = GameObject.FindGameObjectWithTag("Player");
        myTargetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myAnim = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        myRigidBody.velocity = Vector2.zero;
        CheckAttackAndMove();
    }

    private void CheckAttackAndMove()
    {
        if (!myAnim.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && !myAnim.GetCurrentAnimatorStateInfo(0).IsTag("PreAttack")) //if not currently attacking
        {
            hitBox.SetActive(false); //remove hitbox from last attack

            myTimeSinceAttack += Time.fixedDeltaTime;
            if (Vector2.Distance(transform.position, myTargetPos.position) < myAttackRange) //if within range to attack
            {
                myAnim.SetBool("isMoving", false);

                if (myTimeSinceAttack >= myAttackCooldown) //if time to attack
                {
                    myTimeSinceAttack = 0;
                    AttackStart();
                }
            }
            else //not within range ot attack
            {
                CheckMove();
            }
        }
        else if (myAnim.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && hitBox.activeSelf == false)
        {
            Attack();
        }
        else
        {
            myAnim.SetBool("isAttacking", false);
        }
    }

    private void CheckMove()
    {
        if (Vector2.Distance(transform.position, myTargetPos.position) < myFollowRange) //if close enough to follow player
        {
            Move();
        }
        else //enemy too far from player
        {
            myAnim.SetBool("isMoving", false);
        }
    }
    private void Move()
    {
        myAnim.SetBool("isMoving", true);
        myRigidBody.MovePosition(Vector2.MoveTowards(transform.position, myTargetPos.position, mySpeed * Time.fixedDeltaTime));
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

    private void AttackStart() //attack start is called to show animation that the enemy is about to attack
    {
        myAnim.SetBool("isAttacking", true);
    }

    private void Attack() //attack is called when the hitbox should appear and the main attack starts
    {
        //set hitbox direction
        if (myAnim.GetFloat("moveX") == 0 && myAnim.GetFloat("moveY") == 1)
        {
            hitBox.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        else if (myAnim.GetFloat("moveX") == 0 && myAnim.GetFloat("moveY") == -1)
        {
            hitBox.transform.localEulerAngles = new Vector3(0, 0, 180);
        }

        else if (myAnim.GetFloat("moveX") == 1 && myAnim.GetFloat("moveY") == 0)
        {
            hitBox.transform.localEulerAngles = new Vector3(0, 0, -90);
        }

        else if (myAnim.GetFloat("moveX") == -1 && myAnim.GetFloat("moveY") == 0)
        {
            hitBox.transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        //set hitbox active
        hitBox.SetActive(true);
    }

    public void TakeDamage(float damage) //called when enemy is hit by players attack
    {
        myHealth -= damage;

        GameObject FP = Instantiate(floatingDamage, new Vector3(this.transform.position.x + Random.Range(-.2f, .2f), this.transform.position.y + Random.Range(-.2f, .2f), -2), Quaternion.identity);
        FP.GetComponent<TextMesh>().text = ("-" + ((int)damage).ToString());

        myHealthBar.SetHealth(myHealth);

        if (myHealth <= 0)
        {
            myTarget.GetComponent<player_control>().Transaction(Random.Range(deathRewardMin, deathRewardMax + 1));
            Destroy(gameObject);
            GameObject drop;
            int randomItemIndex = Random.Range(-3, drops.Length);

            if (randomItemIndex >= 0)
            {
                drop = Instantiate(drops[randomItemIndex].gameObject, new Vector3(this.transform.position.x, this.transform.position.y - 1, -1), Quaternion.identity);
            }
        }
    }

    public float getDamage()
    {
        return myPower;
    }
}
