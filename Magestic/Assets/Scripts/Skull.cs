using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController infdmg = other.GetComponent<PlayerController>();
            /*if (playerController != null)*/
            infdmg.TakeDamage(10);
            FindObjectOfType<AudioManager>().Play("SkullAttack");

            DestroyProjectile();
        }
        else if (other.CompareTag("Wall"))
        {
           
        }


    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
