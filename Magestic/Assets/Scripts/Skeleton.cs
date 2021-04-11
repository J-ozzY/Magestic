using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy // Bere ze skriptu Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    
    public Transform homePosition;
    public float timer;

    private RaycastHit2D hit;
    private float distance;


    private bool attackMode;
    private bool inRange;
    private bool cooling;// Time btw attacks
    private float intTimer;
    


    private void Awake()
    {
        intTimer = timer;

    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(transform.position, target.position, attackRadius);
            RayDebugger();
        }
        CheckDistance();
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            
                inRange = true;
        }
    }


    void CheckDistance()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        

        if(Vector3.Distance(target.position,
                                transform.position)<= chaseRadius
                        && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            Vector3 temp = transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            myRigidbody.MovePosition(temp);
        }
        //else if(Vector3.Distance(target.position, transform.position)<= attackRadius)
        //{

        //}

        
    
    }





    void RayDebugger()
    {
        if(distance > attackRadius)
        {
            Debug.DrawRay(transform.position, target.position * attackRadius, Color.red);
        }
        else if(attackRadius > distance)
        {
            Debug.DrawRay(transform.position, target.position * attackRadius, Color.green);
        }
    }







}
