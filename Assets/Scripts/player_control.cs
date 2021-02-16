using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_control : MonoBehaviour
{
    // Variables
    private Rigidbody2D myRigidBody;

    private Animator myAnim;

    private float myBaseSpeed = 10f;
    private float myRunningSpeed = 20f;
    private float mySpeed;

    private Vector2 myMovement = Vector2.zero;

    private float myMaxEnergy = 20f;
    private float myEnergy;
    private float myAttackEnergy = 4f;
    private float myRunEnergy = 8f;
    private float myEnergyRegen = 2f;

    private float myMaxHealth = 100f;
    private float myHealth;

    public Transform camTF;

    public HealthBar myHealthBar;
    public EnergyBar myEnergyBar;

    public Canvas myPauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myHealthBar.SetMaxHealth(myMaxHealth);
        myHealth = myMaxHealth;
        myEnergyBar.SetEnergy(myMaxEnergy);
        myEnergy = myMaxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        CheckRunning();
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

    private void CheckRunning()
    {
        if (myEnergy >= 1 && Input.GetKey(KeyCode.LeftShift))
        {
            myEnergy -= myRunEnergy * Time.deltaTime;
            mySpeed = myRunningSpeed;
        }
        else 
        {
            mySpeed = myBaseSpeed;
        }
    }


    private void CheckAttack()
    {
        myEnergy += myEnergyRegen * Time.deltaTime;
        if (myEnergy > myMaxEnergy)
        {
            myEnergy = myMaxEnergy;
        }
        myEnergyBar.SetEnergy(myEnergy);
        if (Input.GetKeyDown(KeyCode.Space) && myEnergy >= myAttackEnergy)
        {
            myAnim.SetBool("isAttacking", true);
            myEnergy -= myAttackEnergy;
            myEnergyBar.SetEnergy(myEnergy);
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
        if (myHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
