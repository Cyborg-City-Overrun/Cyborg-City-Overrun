using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_control : MonoBehaviour
{
    // Variables
    private Rigidbody2D myRigidBody;

    private Animator myAnim;

    private float mySpeed = 10f;

    private Vector2 myMovement = Vector2.zero;

    private float myAttackCooldown = 1f;
    private float myTimeSinceAttack;

    private float myMaxHealth = 100f;
    private float myHealth;

    public Transform camTF;

    public HealthBar myHealthBar;
    public AttackBar myAttackBar;

    public Canvas myPauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myHealthBar.SetMaxHealth(myMaxHealth);
        myHealth = myMaxHealth;
        myAttackBar.SetAttackCooldown(myAttackCooldown);
        myTimeSinceAttack = myAttackCooldown;
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
            myPauseMenu.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(5);
        }
    }

    private void Move()
    {
        myRigidBody.velocity = Vector2.zero;
        if (myMovement != Vector2.zero)
        {
            myRigidBody.MovePosition(myRigidBody.position + myMovement * mySpeed * Time.deltaTime);
            myAnim.SetFloat("moveX", myMovement.x);
            myAnim.SetFloat("moveY", myMovement.y);
            myAnim.SetBool("moving", true);
        }
        else
        {
            myAnim.SetBool("moving", false);
        }
    }


    private void CheckAttack()
    {
        myTimeSinceAttack += Time.deltaTime;
        myAttackBar.SetTime(myTimeSinceAttack);
        if (Input.GetKeyDown(KeyCode.Space) && myTimeSinceAttack >= myAttackCooldown)
        {
            myAnim.SetBool("isAttacking", true);
            myTimeSinceAttack = 0;
            myAttackBar.SetTime(myTimeSinceAttack);
        }
        else
        {
            myAnim.SetBool("isAttacking", false);
        }
    }

    public void TakeDamage(float damage)
    {
        myHealth -= damage;
        myHealthBar.SetHealth(myHealth);
    }
}
