using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieProj : MonoBehaviour
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

            DestroyProjectile();
        }
        else if (other.CompareTag("Wall"))
        {
            DestroyProjectile();
        }


    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
