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
    private float myRunningSpeed = 30f;
    private float mySpeed;

    private Vector2 myMovement = Vector2.zero;

    private float myMaxEnergy = 20f;
    private float myEnergy;
    private float myAttackEnergy = 4f;
    private float myRunEnergy = 15f;
    private float myEnergyRegen = 2f;

    private float myMaxHealth = 100f;
    private float myHealth;

    public Transform camTF;

    public HealthBar HealthBar;
    public EnergyBar EnergyBar;

    public Canvas PauseMenu;

    public BoxCollider2D InteractHitbox;

    public int money;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        HealthBar.SetMaxHealth(myMaxHealth);
        myHealth = myMaxHealth;
        EnergyBar.SetEnergy(myMaxEnergy);
        myEnergy = myMaxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        myMovement.x = Input.GetAxisRaw("Horizontal");
        myMovement.y = Input.GetAxisRaw("Vertical");
        Move();
        CheckAttack();
        Interact();

        camTF.position = new Vector3(this.transform.position.x, this.transform.position.y,-10f);

        //Code added by Tim to go back to Main menu if button M is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            PauseMenu.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.K)) //just for testing, restores all health and energy
        {
            RestoreHealth(10000);
            RestoreEnergy(10000);
        }
    }

    private void Move()
    {
        myRigidBody.velocity = Vector2.zero;
        if (myMovement != Vector2.zero)
        {
            CheckRunning();
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
        if (myEnergy > 0 && Input.GetKey(KeyCode.LeftShift))
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
        RestoreEnergy(myEnergyRegen * Time.deltaTime);
        EnergyBar.SetEnergy(myEnergy);
        if (Input.GetKeyDown(KeyCode.Space) && myEnergy >= myAttackEnergy)
        {
            myAnim.SetBool("isAttacking", true);
            DrainEnergy(myAttackEnergy);
            EnergyBar.SetEnergy(myEnergy);
        }
        else
        {
            myAnim.SetBool("isAttacking", false);
        }
    }

    private void Interact()
    {
        //make a hitbox to interact with things in the world
        if (Input.GetKey(KeyCode.E))
        {
            InteractHitbox.gameObject.SetActive(true);
        }
        else
        {
            InteractHitbox.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(float damage)
    {
        myHealth -= damage;
        if (myHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
        HealthBar.SetHealth(myHealth);
    }
    
    public void RestoreHealth(float health)
    {
        myHealth += health;
        if (myHealth > myMaxHealth)
        {
            myHealth = myMaxHealth;
        }
        HealthBar.SetHealth(myHealth);
    }

    public void DrainEnergy(float energy)
    {
        myEnergy -= energy;
        if (myEnergy < 0)
        {
            myHealth = 0;
        }
    }

    public void RestoreEnergy(float energy)
    {
        myEnergy += energy;
        if (myEnergy > myMaxEnergy)
        {
            myEnergy = myMaxEnergy;
        }
    }
    
}
