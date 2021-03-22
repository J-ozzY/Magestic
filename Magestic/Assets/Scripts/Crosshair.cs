using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class Crosshair : MonoBehaviour
{
    private Vector2 mousePosition;
        
    public Texture2D crossHair;
    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    //public Camera sceneCamera;


    void Start()
    {
        Cursor.SetCursor(crossHair, hotSpot, curMode);
    }

    void FixedUpdate()
    {
        
    }

    void ProcessInputs()
    {
        // mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = (pos);

    }
}