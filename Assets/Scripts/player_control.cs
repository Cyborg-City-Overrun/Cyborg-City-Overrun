using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_control : MonoBehaviour
{
    // Variables
    private Rigidbody2D myRigidBody;

    private Animator myAnim;

    private float myBaseSpeed = 3.5f;
    private float myRunningSpeed = 8f;
    private float mySpeed;

    private Vector2 myMovement = Vector2.zero;

    private float myMaxEnergy = 50f;
    private float myEnergy;
    private float myRunEnergy = 50f;
    private float myEnergyRegen = 25f;

    private float myMaxHealth = 100f;
    private float myHealth;

    public Transform camTF;

    public HealthBar HealthBar;
    public EnergyBar EnergyBar;

    public Canvas PauseMenu;

    public Canvas DeathMenu;

    public Canvas InventoryMenu;

    public BoxCollider2D InteractHitbox;

    public GameObject[] hitBoxes;
    public int boxIndex;
    private float HBActive = 0;

    public int myMoney;

    private sword_list swordList;
    private sword_class mySword;

    public GameObject[] myPotions;
    public GameObject[] myMaterials;
    public GameObject[] myHilts;

    private float myAttackModifier = 1;
    private float myAttackModifierPotion = 1;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject go in hitBoxes)
        {
            go.SetActive(false);
        }
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        HealthBar.SetMaxHealth(myMaxHealth);
        HealthBar.SetHealth(myMaxHealth);
        myHealth = PlayerPrefs.GetFloat("Health");
        EnergyBar.SetMaxEnergy(myMaxEnergy);
        EnergyBar.SetEnergy(PlayerPrefs.GetFloat("Energy"));
        myEnergy = myMaxEnergy;
        swordList = GetComponent<sword_list>();
        myMoney = PlayerPrefs.GetInt("MoneyAmt");
    }

    private void Update()
    {
        if (mySword == null)
        {
            mySword = swordList.getSword(0);
        }

        SwitchWeapon();
        ConsumePotions();
        Interact();
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -4);

        myMovement.x = Input.GetAxisRaw("Horizontal");
        myMovement.y = Input.GetAxisRaw("Vertical");
        Move();
        CheckAttack();

        camTF.position = new Vector3(this.transform.position.x, this.transform.position.y, -10f);

        //Code added by Tim to go back to Main menu if button M is pressed
        if (Input.GetKey(KeyCode.M))
        {
            PauseMenu.gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.T))
        {
            InventoryMenu.gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.K)) //just for testing, restores all health and energy
        {
            RestoreHealth(10000);
            RestoreEnergy(10000);
        }
        if (Input.GetKey(KeyCode.L)) //just for testing, restores all health and energy
        {
            Transaction(100);
        }
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "EnemyAttack") //if the player is hit by an enemy
        {
            TakeDamage(hit.GetComponentInParent<enemy_control>().getDamage());
        }
    }

    private void Move()
    {
        myRigidBody.velocity = Vector2.zero;
        if (myMovement != Vector2.zero)
        {
            CheckRunning();
            myAnim.SetFloat("moveX", myMovement.x);
            myAnim.SetFloat("moveY", myMovement.y);
            myAnim.SetBool("moving", true);
            if (myMovement.x * myMovement.y == 0) //not moving at a diagonal
            {
                myRigidBody.MovePosition(myRigidBody.position + myMovement * mySpeed * Time.fixedDeltaTime);
            }
            else //moving at a diagonal
            {
                myRigidBody.MovePosition(myRigidBody.position + myMovement * (mySpeed / 2) * Time.fixedDeltaTime);
            }
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
            myEnergy -= myRunEnergy * Time.fixedDeltaTime;
            mySpeed = myRunningSpeed;
        }
        else
        {
            mySpeed = myBaseSpeed;
        }
    }


    private void CheckAttack()
    {
        RestoreEnergy(myEnergyRegen * Time.fixedDeltaTime);
        EnergyBar.SetEnergy(myEnergy);

        if (Input.GetKey(KeyCode.Space) && myEnergy >= mySword.GetAttackEnergyWithModifier()
                && !myAnim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            myAnim.SetBool("isAttacking", true);
            myAnim.SetInteger("swordID", mySword.GetID());
            DrainEnergy(mySword.GetAttackEnergyWithModifier());
            EnergyBar.SetEnergy(myEnergy);

            if (myAnim.GetFloat("moveX") == 0 && myAnim.GetFloat("moveY") == 1)
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
            if (hitBoxes[boxIndex].activeSelf == true && HBActive < .18f)
            {
                HBActive += Time.fixedDeltaTime;
            }
            else
            {
                hitBoxes[boxIndex].SetActive(false);
                HBActive = 0;
            }
        }
    }

    private void ConsumePotions()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            myPotions[0].GetComponent<potions>().ConsumePotion();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            myPotions[1].GetComponent<potions>().ConsumePotion();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            myPotions[2].GetComponent<potions>().ConsumePotion();
        }

    }

    private void Interact()
    {
        //make a hitbox to interact with things in the world
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractHitbox.gameObject.SetActive(true);
        }
        else if (!Input.GetKey(KeyCode.E))
        {
            InteractHitbox.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(float damage)
    {
        myHealth -= damage;
        if (myHealth <= 0)
        {
            //Time.timeScale = 0;
            DeathMenu.gameObject.SetActive(true);
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
            myEnergy = 0;
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
        if (myMoney + amount >= 0)
        {
            myMoney += amount;
            print("purchased " + amount);
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            do
            {
                if (mySword.GetID() < swordList.getNumSwords() - 1)
                {
                    mySword = swordList.getSword(mySword.GetID() + 1);
                }
                else
                {
                    mySword = swordList.getSword(0);
                }
            } while (mySword.GetUnlocked() == false);
            
            print("current sword: " + mySword.GetName());
            boxIndex = mySword.GetSize();
        }
    }

    public void SetWeapon(int id)
    {
        if (swordList.getSword(id).GetUnlocked() == true)
        {
            mySword = swordList.getSword(id);
            print("current sword: " + mySword.GetName());
        }
        else
        {
            print("That Sword is not unlocked yet");
        }
    }

    public sword_class GetSword()
    {
        return mySword;
    }

    public void setAttackModifier(float modifier)
    {
        myAttackModifier = modifier;
    }

    public void setAttackModifierPotion(float modifier)
    {
        myAttackModifierPotion = modifier;
    }

    public float getDamage()
    {
        return mySword.GetDamageWithModifier() * myAttackModifier * myAttackModifierPotion;
    }

    public float getMyHealth()
    {
        return myHealth;
    }
    public void setMyHealth(float newHealth)
    {
         this.myHealth = newHealth;
    }

    public float getMyEnergy()
    {
        return myEnergy;
    }

    public void setMyEnergy(float newEnergy)
    {
        this.myEnergy = newEnergy;
    }

    public sword_list getSwordList()
    {
        return swordList;
    }


}
