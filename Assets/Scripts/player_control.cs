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

    private float myMaxEnergy = 50f;
    private float myEnergy;
    private float myRunEnergy = 20f;
    private float myEnergyRegen = 8f;

    private float myMaxHealth = 100f;
    private float myHealth;

    public Transform camTF;

    public HealthBar HealthBar;
    public EnergyBar EnergyBar;

    public Canvas PauseMenu;

    public BoxCollider2D InteractHitbox;

    public GameObject[] hitBoxes;
    public int boxIndex;
    private float HBActive = 0;
  
    public int myMoney = 100;

    private sword_list swordList;
    private sword_class mySword = new sword_class(); //init will be overridden


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
        HealthBar.SetHealth(myMaxHealth);
        myHealth = myMaxHealth;
        EnergyBar.SetMaxEnergy(myMaxEnergy);
        EnergyBar.SetEnergy(myMaxEnergy);
        myEnergy = myMaxEnergy;
        swordList = GetComponent<sword_list>();
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

        if (Input.GetKeyDown(KeyCode.Z) || mySword.getID() < 0)
        {
            SwitchWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Space) && myEnergy >= mySword.getAttackEnergy() 
                && !myAnim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            myAnim.SetBool("isAttacking", true);
            myAnim.SetInteger("swordID", mySword.getID());
            DrainEnergy(mySword.getAttackEnergy());
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
        EnergyBar.SetEnergy(energy);
    }

    public void RestoreEnergy(float energy)
    {
        myEnergy += energy;
        if (myEnergy > myMaxEnergy)
        {
            myEnergy = myMaxEnergy;
        }
        EnergyBar.SetEnergy(energy);
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

    public void SwitchWeapon()
    {
        if (mySword.getID() < swordList.getNumSwords() - 1)
        {
            mySword = swordList.getSword(mySword.getID() + 1);
        }
        else
        {
            mySword = swordList.getSword(0);
        }
        print("current swordID: " + mySword.getID());
        boxIndex = mySword.getSize();
    }

    public sword_class GetSword()
    {
        return mySword;
    }
}
