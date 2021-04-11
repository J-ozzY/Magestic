using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skelet : MonoBehaviour
{

    private Animator anim;
    Rigidbody2D rb;


    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    //public void isMoving()
    //{
    //    if (rb.velocity.x >= 0.01f) { 
    //        anim.SetBool("move", true);
    //    }
    //    else if (rb.velocity.x <= 0.01f)
    //    {
    //        anim.SetBool("move", false);
    //    }

    //    if (rb.velocity.y > 0.01f)
    //    {
    //        anim.SetBool("move", true);
    //    }
    //    else if (rb.velocity.y <= 0.01f)
    //    {
    //        anim.SetBool("move", false);
    //    }

    //}
}
