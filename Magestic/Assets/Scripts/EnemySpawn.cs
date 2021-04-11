using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject roomtoenable;
    public static bool disabled = true;

    public void Start()
    {
        deSpawn();
    }

    private void Update()
    {
        
    }

    public void deSpawn()
    {
        roomtoenable.SetActive(false);
    }

    public void Spawn(bool p)
    {
        roomtoenable.SetActive(p);
    }


}
