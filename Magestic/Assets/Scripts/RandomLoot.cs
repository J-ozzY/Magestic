using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLoot : MonoBehaviour
{
    public List<GameObject> idrops;
    public int[] table =
    {
        40, //coin
        20, //small health
        10  //big healt
    };

    public int total;
    public int randomNumber;


    void Start()
    {

        //foreach (var item in table)
        //{
        //    total += item;
        //}

        //randomNumber = Random.Range(0, total);

        //for(int i=0; i< table.Length; i++)
        //{
        //    if(randomNumber <= table[i])
        //    {
        //       Instantiate(idrops[i], transform.position, Quaternion.identity); ;
        //        return;
        //    }
        //    else
        //    {
        //        randomNumber -= table[i];
        //    }
        //}
    }


    void Update()
    {
        
    }

    public void ItemDrop()
    {
        foreach (var item in table)
        {
            total += item;
        }

        randomNumber = Random.Range(0, total);

        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                Instantiate(idrops[i], transform.position, Quaternion.identity); ;
                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }
    }

}
