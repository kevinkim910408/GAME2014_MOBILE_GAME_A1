using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: ObjectPooling.cs
/// Date last Modified: 2020-10-12
/// Program description
///  - Object Pooling - use arrays to contain objects, and when they are needed, i will generate (for optimization).
///                   - create objects before runtime. 
///  
/// Revision History
/// 2020-10-12: Object pooling
/// </summary>
/// 

public class ObjectPooling : MonoBehaviour
{
    #region Variables
    // contains prefabs
    public GameObject enemy_L_Prefab;
    public GameObject enemy_M_Prefab;
    public GameObject enemy_S_Prefab;
    public GameObject item_Coin_Prefab;
    public GameObject item_Power_Prefab;
    public GameObject Bullet_Player_A_Prefab;
    public GameObject Bullet_Player_B_Prefab;
    public GameObject Bullet_Enemy_A_Prefab;
    public GameObject Bullet_Enemy_B_Prefab;

    // array contatins actual objects
    GameObject[] enemy_L;
    GameObject[] enemy_M;
    GameObject[] enemy_S;

    GameObject[] item_Coin;
    GameObject[] item_Power;

    GameObject[] Bullet_Player_A;
    GameObject[] Bullet_Player_B;
    GameObject[] Bullet_Enemy_A;
    GameObject[] Bullet_Enemy_B;

    // to manage making objects
    GameObject[] targetObjectPool;
    #endregion

    #region Unity_Method
    private void Awake()
    {
        // set the production limits of prefabs
        enemy_L = new GameObject[20];
        enemy_M = new GameObject[20];
        enemy_S = new GameObject[20];

        item_Coin = new GameObject[20];
        item_Power = new GameObject[20];

        Bullet_Player_A = new GameObject[1000];
        Bullet_Player_B = new GameObject[1000];
        Bullet_Enemy_A = new GameObject[1000];
        Bullet_Enemy_B = new GameObject[1000];

        Generate();
    }

    #endregion

    #region Custom_Method
    void Generate()
    {
        // Generate Enemies 
        for(int i = 0; i < enemy_L.Length; ++i)
        {
            // push the prefabs to the array
            enemy_L[i] = Instantiate(enemy_L_Prefab);
            // at first, prefabs set active false --> will generate when they are needed.
            enemy_L[i].SetActive(false);
        }

        for (int i = 0; i < enemy_M.Length; ++i)
        {
            enemy_M[i] = Instantiate(enemy_M_Prefab);
            enemy_M[i].SetActive(false);
        }

        for (int i = 0; i < enemy_S.Length; ++i)
        {
            enemy_S[i] = Instantiate(enemy_S_Prefab);
            enemy_S[i].SetActive(false);
        }

        // Generate Items
        for (int i = 0; i < item_Coin.Length; ++i)
        {
            item_Coin[i] = Instantiate(item_Coin_Prefab);
            item_Coin[i].SetActive(false);
        }

        for (int i = 0; i < item_Power.Length; ++i)
        {
            item_Power[i] = Instantiate(item_Power_Prefab);
            item_Power[i].SetActive(false);
        }

        // Generate Bullets
        for (int i = 0; i < Bullet_Player_A.Length; ++i)
        {
            Bullet_Player_A[i] = Instantiate(Bullet_Player_A_Prefab);
            Bullet_Player_A[i].SetActive(false);

        }

        for (int i = 0; i < Bullet_Player_B.Length; ++i)
        {
            Bullet_Player_B[i] = Instantiate(Bullet_Player_B_Prefab);
            Bullet_Player_B[i].SetActive(false);

        }

        for (int i = 0; i < Bullet_Enemy_A.Length; ++i)
        {
            Bullet_Enemy_A[i] = Instantiate(Bullet_Enemy_A_Prefab);
            Bullet_Enemy_A[i].SetActive(false);

        }

        for (int i = 0; i < Bullet_Enemy_B.Length; ++i)
        {
            Bullet_Enemy_B[i] = Instantiate(Bullet_Enemy_B_Prefab);
            Bullet_Enemy_B[i].SetActive(false);

        }
    }
    
    // actual function of making object
    public GameObject MakeObject(string type)
    {
        // Make object according to the types
        switch (type)
        {
            // Enemies
            case "EnemyL":
                targetObjectPool = enemy_L;
                break;
            case "EnemyM":
                targetObjectPool = enemy_M;
                break;
            case "EnemyS":
                targetObjectPool = enemy_S;
                break;

            // Items
            case "ItemPower":
                targetObjectPool = item_Power;
                break;
            case "ItemCoin":
                targetObjectPool = item_Coin;
                break;

            // Bullets
            case "PlayerBulletA":
                targetObjectPool = Bullet_Player_A;
                break;
            case "PlayerBulletB":
                targetObjectPool = Bullet_Player_B;
                break;
            case "EnemyBulletA":
                targetObjectPool = Bullet_Enemy_A;
                break;
            case "EnemyBulletB":
                targetObjectPool = Bullet_Enemy_B;
                break;
        }

        for (int i = 0; i < targetObjectPool.Length; ++i)
        {
            // if targetObjectPool is not active.
            if (!targetObjectPool[i].activeSelf)
            {
                // make it active
                targetObjectPool[i].SetActive(true);
                return targetObjectPool[i];
            }

        }

        // for fixing error of red underline here --> public GameObject MakeObject(string type)
        return null;
    }

    #endregion
}
