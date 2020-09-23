using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: EnmeyManager.cs
/// Date last Modified: 2020-09-23
/// Program description
///  - Managing enemies' spawn.
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// </summary>
/// 
public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemies;

    public Transform[] spawnPositions;
    public float maxDelay;
    public float currentDelay;

    private void Update()
    {
        currentDelay += Time.deltaTime;

        if(currentDelay > maxDelay)
        {
            SpawnEnemy();
            maxDelay = Random.Range(0.5f, 2.0f);
            currentDelay = 0;
        }
    }

    void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, 3);
        int randomPosition = Random.Range(0, 5);

        Instantiate(enemies[randomEnemy],spawnPositions[randomPosition].position, spawnPositions[randomPosition].rotation);
    }
}
