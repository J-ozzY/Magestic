using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Zombie : MonoBehaviour
{
    public Transform player;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float attackDistance;

    private Light2D lightatck;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        
    }



    void Shoot()
    {
        
        if (Vector2.Distance(transform.position, player.position) > attackDistance)
        {
            return;


        }


        if (timeBtwShots <= 0)
        {
            PlayerController infdmg = player.GetComponent<PlayerController>();
            infdmg.TakeDamage(5);
            FindObjectOfType<AudioManager>().Play("ZombieAttack");

            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    PlayerController player = collider.GetComponent<PlayerController>();
    //    if (player != null)
    //    {
    //        //player in!

    //    }
    //}

}
