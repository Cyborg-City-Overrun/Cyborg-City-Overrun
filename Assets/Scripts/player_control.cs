using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_control : MonoBehaviour
{
    // Variables
    private Rigidbody2D myRigidBody;

    private Animator myAnim;

    private float mySpeed = 3f;

    private Vector2 myMovement = Vector2.zero;

    private float myAttackCooldown = 10f;
    private float timeSinceAttack = 0;

    private float myMaxHealth = 100f;
    private float myHealth;

    public Transform camTF;

    public HealthBar myHealthBar;
    public AttackBar myAttackBar;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myHealthBar.SetMaxHealth(myMaxHealth);
        myHealth = myMaxHealth;
        myAttackBar.SetAttackCooldown(myAttackCooldown);
        myAttackCooldown = myAttackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        myMovement.x = Input.GetAxisRaw("Horizontal");
        myMovement.y = Input.GetAxisRaw("Vertical");
        Move();
        CheckAttack();

        camTF.position = new Vector3(this.transform.position.x, this.transform.position.y,-10f);

        //Code added by Tim to go back to Main menu if button M is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(5);
        }
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
        myAttackBar.SetTime(timeSinceAttack);
        if (Input.GetKeyDown(KeyCode.Space) && timeSinceAttack >= myAttackCooldown)
        {
            myAnim.SetBool("isAttacking", true);
            timeSinceAttack = 0;
            myAttackBar.SetTime(timeSinceAttack);
        }
        else
        {
            myAnim.SetBool("isAttacking", false);

        }
    }

    void TakeDamage(float damage)
    {
        myHealth -= damage;
        myHealthBar.SetHealth(myHealth);
    }
}
