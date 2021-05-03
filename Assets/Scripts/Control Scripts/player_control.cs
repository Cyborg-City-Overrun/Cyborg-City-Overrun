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
    private float myEnergyRegen = 20f;

    private float myMaxHealth = 100f;
    private float myHealth;

    public Transform camTF;

    public HealthBar HealthBar;
    public EnergyBar EnergyBar;

    public Canvas PauseMenu;

    public Canvas DeathMenu;

    public Canvas InventoryMenu;

    public Canvas TreeMenu;

    public BoxCollider2D InteractHitbox;

    public GameObject[] hitBoxes;
    public int boxIndex;
    private float HBActive = 0;

    public int myMoney;

    public int mySkillPointsRed;
    public int mySkillPointsGreen;
    public int mySkillPointsYellow;

    private sword_list swordList;
    private sword_class mySword;

    public GameObject[] myPotions;
    public GameObject[] myMaterials;
    public GameObject[] myHilts;

    private float myAttackModifier = 1;
    private float myAttackModifierPotion = 1;

    private tree_list treeList;

    private bool canMove = true;

    private GameObject keyManager;
    private KeyBindScript keyScript;

    public AudioSource audioSource;

    private Saver save;
    

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
        treeList = GetComponent<tree_list>();
        mySkillPointsRed = 0;
        mySkillPointsGreen = 0;
        mySkillPointsYellow = 0;

        keyManager = GameObject.FindGameObjectWithTag("KeyManager");
        keyScript = keyManager.GetComponent<KeyBindScript>();

        save = FindObjectOfType<Saver>();

    }

    private void Update()
    {
        UpdateHealth();

        if (mySword == null)
        {
            mySword = swordList.getSword(0);
        }

        if (canMove)
        {
            SwitchWeapon();
            Interact();

            ConsumePotions();
        }

        if (!canMove)
        {
            myAnim.GetComponent<Animator>().Play("Idle", 0);
        }

        UpdateAudio();
    }

    void UpdateAudio()
    {
        audioSource.volume = PlayerPrefs.GetFloat("Volume");
    }

    void FixedUpdate()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, -4);

        myMovement.x = Input.GetAxisRaw("Horizontal");
        myMovement.y = Input.GetAxisRaw("Vertical");
        if (canMove)
        {
            Move();
            CheckAttack();
        }

        camTF.position = new Vector3(this.transform.position.x, this.transform.position.y, -10f);

        //Code added by Tim to go back to Main menu if button M is pressed
        if (Input.GetKey(keyScript.GetKey("PauseMenuControl")))
        {
            PauseMenu.gameObject.SetActive(true);
        }

        if (Input.GetKey(keyScript.GetKey("InventoryControl")))
        {
            InventoryMenu.gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.K)) //just for testing, restores all health and energy
        {
            //RestoreHealth(10000);
            //RestoreEnergy(10000);
        }
        if (Input.GetKey(KeyCode.L)) //just for testing, gives money
        {
            //Transaction(100);
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
        if (myEnergy > 0 && Input.GetKey(keyScript.GetKey("RunControl")))
        {
            myEnergy -= myRunEnergy * treeList.GetTreeWithTag("Energy").GetActiveBranchWithTag("RunEnergy").GetModifier() * Time.fixedDeltaTime;
            mySpeed = myRunningSpeed * treeList.GetTreeWithTag("Energy").GetActiveBranchWithTag("RunSpeed").GetModifier();
        }
        else
        {
            mySpeed = myBaseSpeed * treeList.GetTreeWithTag("Energy").GetActiveBranchWithTag("WalkSpeed").GetModifier();
        }
    }


    private void CheckAttack()
    {
        RestoreEnergy(myEnergyRegen * treeList.GetTreeWithTag("Energy").GetActiveBranchWithTag("EnergyRegen").GetModifier() * Time.fixedDeltaTime);
        EnergyBar.SetEnergy(myEnergy);

        if (Input.GetKey(keyScript.GetKey("AttackControl")) && myEnergy >= mySword.GetAttackEnergyWithModifier()
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
        if (Input.GetKeyDown(keyScript.GetKey("HealthPotionControl")))
        {
            myPotions[0].GetComponent<potions>().ConsumePotion();
        }

        if (Input.GetKeyDown(keyScript.GetKey("EnergyPotionControl")))
        {
            myPotions[1].GetComponent<potions>().ConsumePotion();
        }

        if (Input.GetKeyDown(keyScript.GetKey("AttackBuffPotionControl")))
        {
            myPotions[2].GetComponent<potions>().ConsumePotion();
        }

    }

    private void UpdateHealth()
    {
        myMaxHealth = treeList.GetTreeWithTag("Health").GetActiveBranchWithTag("HealthIncrease").GetModifier();

        HealthBar.SetMaxHealth(myMaxHealth);
        HealthBar.SetHealth(myHealth);

        RestoreHealth(treeList.GetTreeWithTag("Health").GetActiveBranchWithTag("HealthRegen").GetModifier() * Time.fixedDeltaTime);
    }

    private void Interact()
    {
        //make a hitbox to interact with things in the world
        if (Input.GetKey(keyScript.GetKey("InteractControl")))
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
            save.saveGame();

            DeathMenu.gameObject.SetActive(true);
        }
        HealthBar.SetHealth(myHealth);
    }

    public void RestoreHealth(float health)
    {
        if (health >= 0)
        {
            myHealth += health * treeList.GetTreeWithTag("Health").GetActiveBranchWithTag("HealthRecovery").GetModifier();
        }
        else
        {
            myHealth += health;
        }

        if (myHealth > myMaxHealth)
        {
            myHealth = myMaxHealth;
        }

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
        if (Input.GetKeyDown(keyScript.GetKey("SwordSwitchControl")))
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

    public void setAttackModifier() //not in use. can probably delete
    {
        myAttackModifier = treeList.GetTreeWithTag("Damage").GetActiveBranchWithTag("DamageBuff").GetModifier();
    }

    public void setAttackModifierPotion(float modifier)
    {
        myAttackModifierPotion = modifier;
    }

    public float getDamage()
    {
        return mySword.GetDamageWithModifier() * treeList.GetTreeWithTag("Damage").GetActiveBranchWithTag("DamageBuff").GetModifier() * myAttackModifierPotion;
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

    public void setCanMove(bool newState)
    {
        this.canMove = newState;
    }
    public bool UseSkillPoint(string type)
    {
        switch(type)
        {
            case "Red":
                if (mySkillPointsRed > 0)
                {
                    mySkillPointsRed--;
                    return true;
                }
                break;
            case "Green":
                if (mySkillPointsGreen > 0)
                {
                    mySkillPointsGreen--;
                    return true;
                }
                break;
            case "Yellow":
                if (mySkillPointsYellow > 0)
                {
                    mySkillPointsYellow--;
                    return true;
                }
                break;
        }
        
        return false;
    }

    public int GetSkillPoints(string type)
    {
        switch (type)
        {
            case "Red":
                return mySkillPointsRed;
            case "Green":
                return mySkillPointsGreen;
            case "Yellow":
                return mySkillPointsYellow;
        }
        return 0;
    }

    public void AddSkillPoints(string type)
    {
        switch (type)
        {
            case "Red":
                mySkillPointsRed++;
                break;
            case "Green":
                mySkillPointsGreen++;
                break;
            case "Yellow":
                mySkillPointsYellow++;
                break;
        }
    }

    public void OpenUpgradeMenu()
    {
        TreeMenu.gameObject.SetActive(true);
    }
    public void CloseUpgradeMenu()
    {
        TreeMenu.gameObject.SetActive(false);
    }
}