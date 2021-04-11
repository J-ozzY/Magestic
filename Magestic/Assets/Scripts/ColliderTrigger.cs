using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public float timeToDestroy;
    public float startTimeTodes;
    public float walltoexit;
    public GameObject wall;
    public Collider2D ColliderOfTheRoom;
    private bool zapnout = false;


    public event EventHandler OnPlayerEnterTrigger;

    private void Start()
    {
        //timeToDestroy = startTimeTodes;
        
    }
   
    
    private void FixedUpdate()
    {
        if (zapnout == false) return;
        if (zapnout == true) { 
            
            if (timeToDestroy <= 0)
            {
            
                    WallDes();
                    zapnout = false;
                    return;
            }
             else
             {
                        timeToDestroy -= Time.deltaTime;
                ColliderOfTheRoom.enabled = false;     
             }
        }
    
    
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerController player = collider.GetComponent<PlayerController>();

        if (player != null)
        {
            //player in!
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty );
            timeToDestroy = startTimeTodes;
            wall.SetActive(true);
            zapnout = true;
        }

        
        
    }
        public void WallDes()
        {
            wall.SetActive(false);
            //ColliderOfTheRoom.SetActive(false);
        }
}