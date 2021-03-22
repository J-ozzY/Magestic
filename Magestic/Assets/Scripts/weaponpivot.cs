using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponpivot : MonoBehaviour
{
   




    void Update()
    {
        faceMouse();
    }
    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direcrion = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);

        transform.up = direcrion;
    }

    //private void Update()             ---- kouká na statický crosshair
    //{
    //    mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    //    Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    //    Vector2 exitPoint = new Vector2(crosshair.transform.position.x, crosshair.transform.position.y);
    //    Vector2 direction = target - exitPoint;
    //    direction.Normalize();

    //    Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    //    transform.rotation = rotation;

    //} ----- konec neceho co nefunguje

    // private void FixedUpdate()
    // {


    //    Vector2 lookDir = mousePos - rbz.position;
    //    float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
    //    rbz.rotation = angle;



    //}




}
