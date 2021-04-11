using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private ColliderTrigger colliderTrigger;

    

    private void Start()
    {
        

        colliderTrigger.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
    }

    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        StartBattle();
    }

    private void StartBattle()
    {
        Debug.Log("battle start");
        GetComponent<EnemySpawn>().Spawn(true);
        colliderTrigger.OnPlayerEnterTrigger -= ColliderTrigger_OnPlayerEnterTrigger;
    }

}
