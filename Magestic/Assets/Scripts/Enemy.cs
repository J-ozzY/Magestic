using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}


public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public int helth;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            helth--;
            if (helth <= 0)
            {
                FindObjectOfType<AudioManager>().Play("EnemyDeath");
                GetComponent<RandomLoot>().ItemDrop();
                Destroy(gameObject);

            }
        }
    }




}
