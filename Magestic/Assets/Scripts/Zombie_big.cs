using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_big : MonoBehaviour
{

    private float timeBtwShots;
    public float startTimeBtwShots;
    public Rigidbody2D rb;
    public Transform player;
    
    public float attackDistance;

    [Header("bulletHellProjectile")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject MiniZombieprojectile;

    [Header("variables")]
    private Vector3 startPoint;
    private const float radius = 1f;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
                //Move_en();
                Shoot();
                break;
            }
        }


    }

    void Shoot()
    {
        //if (Vector2.Distance(transform.position, player.position) <= attackDistance)
        //{
        //    timeBtwShots = startTimeBtwShots;

        //}



        if (timeBtwShots <= 0)
        {
            SpawnProjectile(numberOfProjectiles);
            FindObjectOfType<AudioManager>().Play("BigZombieAttack");
            //projectile.GetComponent<Rigidbody2D>().AddForce(transform.position * projSpeed, ForceMode2D.Impulse);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    
        
    }
    private void SpawnProjectile(int numOfProj)
    {
        float angleStep = 360f / numOfProj;
        float angle = 0f;

        for(int i = 0; i<= numOfProj -1 ; i++)
        {
            float projectileDirXPositoin = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPositoin = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(projectileDirXPositoin, projectileDirYPositoin, 0);
            Vector3 projectileMoveDir = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject tmpObj = Instantiate(MiniZombieprojectile, transform.position, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDir.x, projectileMoveDir.y,0);
            angle += angleStep;
        }
    }
}
