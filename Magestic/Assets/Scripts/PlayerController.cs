using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int coin = 0;
    public float moveSpeed;
    public Rigidbody2D rb;
    private float timeBtwShots; 
    public float startTimeBtwShots;
    public Animator anim;
    private Vector2 moveDirection;
    public TextMeshProUGUI textCoins;


    public Weapon weapon;



    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play("PlayerTakingDmg");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            Destroy(gameObject);
        }

    }

    public void Heal(int heal)
    {
        
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        }
        if(heal >= 20)
        {
            FindObjectOfType<AudioManager>().Play("bigHeal");
        }
        if (heal <= 18)
        {
            FindObjectOfType<AudioManager>().Play("smallHeal");
        }
    }


    void Update()                    // podle fps
    {
        
        ProcessInputs();
        
    }
    
    

    void FixedUpdate()          // nekolikrat za update
    {
        Move();
        //FlipPlayer();
    }

    internal static int TakeDamage(object d)
    {
        throw new NotImplementedException();
    }

    void ProcessInputs()
    {

       
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if(timeBtwShots <=0){
            if (Input.GetMouseButtonDown(0))
            {
                weapon.Fire();
                timeBtwShots = startTimeBtwShots;
                FindObjectOfType<AudioManager>().Play("PlayerAttack");
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

        anim.SetFloat("Horizontal", moveDirection.x);
        anim.SetFloat("Vertical", moveDirection.y);   //animace



    }


    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);


    }

    

    private void OnTriggerEnter2D(Collider2D healtr)
    {
        if (healtr.gameObject.tag == "smallHeal")
        {
            Heal(12);
        }

        if (healtr.gameObject.tag == "bigHeal")
        {
            Heal(30);
        }
        if(healtr.gameObject.tag == "Coin")
                coin++;
        textCoins.text = coin.ToString();

    }
    


}
