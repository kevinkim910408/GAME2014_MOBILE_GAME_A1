using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: EnmeyManager.cs
/// Date last Modified: 2020-10-07
/// Program description
///  - Managing enemies' spawn.
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// 2020-10-07: Add more Enemy spawn place, inline comments, make code looks clear, removed unnecessary codes
/// </summary>
/// 
public class EnemyManager : MonoBehaviour
{
    #region Variables
    // Enemies' object that EnemyManger can instantiate. Made by array because there are total 3 enemies so far
    [SerializeField]
    GameObject[] enemies;

    // Enemies' Spawning location.
    public Transform[] spawnPositions;

    // Enemies spawn with delay.
    public float maxDelay;
    public float currentDelay;

    #endregion

    #region Unity_Method
    private void Update()
    {
        // current delay = current delay + evety frame 
        currentDelay += Time.deltaTime;

        // if current deay is over max delay
        if(currentDelay > maxDelay)
        {
            // can spawn enemy
            SpawnEnemy();
            // set max delay between 0.5 - 2
            maxDelay = Random.Range(0.5f, 2.0f);

            // reset current delay
            currentDelay = 0;
        }
    }

    #endregion

    #region Custom_Method

    // Spawning Enemies with Instantiate(prefabs)
    void SpawnEnemy()
    {
        // Spawning Random Enemies in the Random Position. There are 3 enemies and 9 locations so far
        int randomEnemy = Random.Range(0, 3);
        int randomPosition = Random.Range(0, 9);

        // actual code of spawning enemies made with Instantiate
        Instantiate(enemies[randomEnemy],spawnPositions[randomPosition].position, spawnPositions[randomPosition].rotation);
    }
    #endregion
}
