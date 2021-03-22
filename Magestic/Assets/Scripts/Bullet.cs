using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rbb;
    public GameObject hitEffect;
    //public GameObject destroyEffect;
    public float lifeTime;
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.4f);
        Destroy(gameObject);
    }

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    void DestroyProjectile()
    {
       GameObject bull = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(bull);
        Destroy(gameObject);
    }


}
