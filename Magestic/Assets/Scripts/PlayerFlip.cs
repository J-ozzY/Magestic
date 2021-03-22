using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{

    public GameObject myPlayer;

    void FixedUpdate()          // nekolikrat za update
    {
        Vector3 differenc = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        differenc.Normalize();
        float ratationZ = Mathf.Atan2(differenc.y, differenc.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);


        if (ratationZ < -90 || ratationZ > 90)
        {
            if (myPlayer.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);


            }
            else if (myPlayer.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, 0);




            }
        }

        
    }


    // Start is called before the first frame update



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

   
}
