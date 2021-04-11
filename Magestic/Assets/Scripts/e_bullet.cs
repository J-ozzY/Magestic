using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_bullet : MonoBehaviour
{ 
    public float speed;
    public float lifeTime;
    private Transform player;
    private Vector2 target;
    public PlayerController playerController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);

        player = GameObject.FindWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); // když projektil doletí na místo kde hráè byl
       
        

        
        //if(transform.position.x == target.x && transform.position.y == target.y){
        //    DestroyProjectile();
        //}

        
    } 
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
            PlayerController infdmg = other.GetComponent<PlayerController>();
            /*if (playerController != null)*/ infdmg.TakeDamage(13);
                
            DestroyProjectile();
            }
            else if (other.CompareTag("Wall"))
            {
            DestroyProjectile();
            }


        }
    
        void DestroyProjectile() {
            Destroy(gameObject);
        }


    
    









}
