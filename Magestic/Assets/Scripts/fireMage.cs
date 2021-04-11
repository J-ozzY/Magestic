using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireMage : Enemy
{


    public float stoppingDistance;
    public float retreatDistance;
    public Transform player;
    public Transform fire_mage;
    public float aggroDistance;
    public float attackDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public Rigidbody2D rb;
    public GameObject projectile;
    //public float projSpeed;



    // Start is called before the first frame update
    void Start()
    {
        //rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);



        CanSeePlayer();


    }

    void CanSeePlayer()
    {



        RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, player.position);


        foreach (RaycastHit2D hit in hits)
        {
            GameObject other = hit.collider.gameObject;
            //Debug.Log(hit.collider.gameObject);
            if (other.CompareTag("Wall"))
            {
                break;
            }
            else if (other.CompareTag("Player"))
            {
                Move_en();
                Shoot();
                break;
            }
        }


    }


    void Shoot()
    {
        if (Vector2.Distance(transform.position, player.position) >= attackDistance)
        {
            timeBtwShots = startTimeBtwShots;

        }



        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("FireMageAttack");
            //projectile.GetComponent<Rigidbody2D>().AddForce(transform.position * projSpeed, ForceMode2D.Impulse);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }


    void Move_en()
    {
        


        if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) <= aggroDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            //rb.velocity = player.position * moveSpeed;
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime);
        }
    }

    

}



            
