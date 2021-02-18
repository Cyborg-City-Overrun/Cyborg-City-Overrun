using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_control : MonoBehaviour
{
    // Variables
    private Rigidbody2D myRigidBody;

    private Animator myAnim;

    public  float myBaseSpeed = 10f;
    public float myRunningSpeed = 30f;
    private float mySpeed;

    private Vector2 myMovement = Vector2.zero;

    public float myMaxEnergy = 20f;
    private float myEnergy;
    public float myAttackEnergy = 4f;
    public float myRunEnergy = 15f;
    public float myEnergyRegen = 3f;

    private float myMaxHealth = 100f;
    private float myHealth;

    public Transform camTF;

    public HealthBar HealthBar;
    public EnergyBar EnergyBar;

    public Canvas PauseMenu;

    public BoxCollider2D InteractHitbox;

    public GameObject[] hitBoxes;
    public int boxIndex;
    public int boxIndexMax;
    private float HBActive = 0;
  
    public int myMoney = 100;

    private sword_list swordList;
    private sword_class mySword;


    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject go in hitBoxes)
        {
            go.SetActive(false);
        }
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        HealthBar.SetMaxHealth(myMaxHealth);
        myHealth = myMaxHealth;
        EnergyBar.SetEnergy(myMaxEnergy);
        myEnergy = myMaxEnergy;
        mySword = swordList.getSword(0);
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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (boxIndex < boxIndexMax)
            {
                boxIndex++;
            }
            else
            {
                boxIndex = 0;
            }
            print("current swordID: " + boxIndex);
        }

        if (Input.GetKeyDown(KeyCode.Space) && myEnergy >= myAttackEnergy)
        {
            myAnim.SetBool("isAttacking", true);
            myAnim.SetInteger("swordID", boxIndex);
            DrainEnergy(myAttackEnergy);
            EnergyBar.SetEnergy(myEnergy);

            if(myAnim.GetFloat("moveX")==0 && myAnim.GetFloat("moveY") == 1)
            {
                hitBoxes[boxIndex].transform.localEulerAngles = new Vector3(0, 0, 0);
            }

            else if (myAnim.GetFloat("moveX") == 0 && myAnim.GetFloat("moveY") == -1)
            {
                hitBoxes[boxIndex].transform.localEulerAngles = new Vector3(0, 0, 180);
            }

            else if (myAnim.GetFloat("moveX") == 1 && myAnim.GetFloat("moveY") == 0)
            {
                hitBoxes[boxIndex].transform.localEulerAngles = new Vector3(0, 0, -90);
            }

            else if (myAnim.GetFloat("moveX") == -1 && myAnim.GetFloat("moveY") == 0)
            {
                hitBoxes[boxIndex].transform.localEulerAngles = new Vector3(0, 0, 90);
            }
            hitBoxes[boxIndex].SetActive(true);
        }
        else
        {
            myAnim.SetBool("isAttacking", false);
            if (hitBoxes[boxIndex].activeSelf==true && HBActive<.18f)
            {
                HBActive += Time.deltaTime;
            }
            else
            {
                hitBoxes[boxIndex].SetActive(false);
                HBActive = 0;
            }

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
            SceneManager.LoadScene(3);
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
    
    public bool Transaction(int amount)
    {
        if (myMoney + amount > 0)
        {
            myMoney += amount;
            print(amount);
            print("you now have " + myMoney);
            return true;
        }
        else
        {
            print("not enough money");
            return false;
        }
    }

    public void setSword(sword_class sword)
    {
        mySword = sword;
    }
}
