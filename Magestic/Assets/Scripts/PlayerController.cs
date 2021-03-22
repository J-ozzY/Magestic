using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private Player player;
    public float moveSpeed;
    //public Camera cam;
    public Rigidbody2D rb;
    //public Rigidbody2D weapon_rb;
    private float timeBtwShots; // pro cas mezi strelami
    public float startTimeBtwShots;
    public Animator anim;
    //public GameObject myPlayer;
    private Vector2 moveDirection;
    //private Vector2 mousePosition;
    //public GameObject CrossHair;

    public Weapon weapon;



    void Update()                    // podle fps
    {
        
        ProcessInputs();
    }

    void FixedUpdate()          // nekolikrat za update
    {
        Move();
        //FlipPlayer();
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
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

        anim.SetFloat("Horizontal", moveDirection.x);    //animace



    }


    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);


    }


    //private void FlipPlayer()
    //{
    //   Vector3 diffrenc = Camera.main.ScreenToWorldPoint(Input.mousePosition) + transform.position;
    //    //Vector3 diffrenc = transform.position;
    //    diffrenc.Normalize();

    //    float ratationZ = Mathf.Atan2(diffrenc.y, diffrenc.x) * Mathf.Rad2Deg;

    //    transform.rotation = Quaternion.Euler(0f, 0f, 0);

    //    if (ratationZ < -90 || ratationZ > 90)
    //    {
    //        if (myPlayer.transform.eulerAngles.y == 0)
    //        {
    //            transform.localRotation = Quaternion.Euler(0, 180, 0);


    //        }
    //        else if (myPlayer.transform.eulerAngles.y == 180)
    //        {
    //            transform.localRotation = Quaternion.Euler(180, 180, 0);




    //        }
    //    }
    
        //end of flip player
    //}
}
