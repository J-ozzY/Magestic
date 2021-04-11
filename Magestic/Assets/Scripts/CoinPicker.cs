using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPicker : MonoBehaviour
{
    private float coin = 0;
    //public TextMeshProUGUI textCoins;

    public Collider2D colliderOfCoin;

    [Header("Coin random move")]
    public Transform objTrans;
    private float delay = 0;
    private float pasttime = 0;
    private float when = 1.0f;
    private Vector3 off;

    [Header("Magnet to player")]
    public Rigidbody2D coinRig;
    public GameObject player;
    private bool magnetize = false;
    [Header("CoinSound")]
    public AudioClip soundEffect;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player")
        {
            //AudioManager.instance.PlayClip(soundEffect);
            //coin++;
            //GetComponent<>
            FindObjectOfType<AudioManager>().Play("CoinPick");
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        off = new Vector3(Random.Range(-3, 3), off.y, off.z);

        off = new Vector3(off.x, Random.Range(-3, 3), off.z);
    }

    private void Start()
    {
        coinRig = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");


        StartCoroutine(Magnet());
            
    }

    private void Update()
    {
        if(when >= delay)
        {
            pasttime = Time.deltaTime;
            delay += pasttime;
        }
        if (magnetize)
        {
            Vector3 playerPoint = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(0, -0.3f, 0), 200 * Time.deltaTime);
            coinRig.MovePosition(playerPoint);
        }
    }

    private IEnumerator Magnet()
    {
        yield return new WaitForSeconds(2f);
        magnetize = true;
    }

}
