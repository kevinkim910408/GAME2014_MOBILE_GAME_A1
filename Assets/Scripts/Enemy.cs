﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: Enmey.cs
/// Date last Modified: 2020-10-17
/// Program description
///  - This script is only for enemies. It contains enemies hp, and movespeed. Also contains enemies sprites to change when enemies are hit by player.
///  - if Enemies and the bullets hit the border --> destroy.
///  - Enmey can fire bullets to player
///  - Enemy can be hit by player
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// 2020-10-07: inline comments + make code looks clear, Enmey can fire
/// 2020-10-12: Enemy drops items
/// 2020-10-13: Added functions about Boss
/// 2020-10-17: Edit Internal Documentation - Add Headers and Inline Comments
/// </summary>
/// 
public class Enemy : MonoBehaviour
{
    #region Variables
    [Header("Basic Stats")]
    // Basic stats for the enemies
    public float moveSpeed;
    public int hp;
    // Enemy's score
    public int enemyScore;


    // Components
    SpriteRenderer spriteRenderer;
   
    // Enemies' sprites
    [SerializeField]
    Sprite[] sprites = null;

    // Enemy projectiles
    [SerializeField]
    GameObject EnemyBulletA;
    [SerializeField]
    GameObject EnemyBulletB;

    // Enemy drops items
    [SerializeField]
    GameObject itemPower;
    [SerializeField]
    GameObject itemCoin;

    //delay Enemy's firing
    [SerializeField]
    float maxReloadingTime = 2.0f;
    [SerializeField]
    float currentReloadingTime;

    // variable for give enemies' bullets
    public string enemyName;

    // Fire to player
    public GameObject player;

    public ObjectPooling objectPooling;

    // Boss animation
    Animator animator;

    // Boss Pattern
    public int patternIndex;
    public int currentPatternCount;
    public int[] maxPatternCount;

    // to Get SFX sound name 
    [SerializeField]
    private string ShootSound;
    [SerializeField]
    private string DieSound;

    #endregion

    #region Unity_Method
    private void Awake()
    {
        // GetComponents
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(enemyName == "Boss")
        {
            animator = GetComponent<Animator>();
        }
    }

    // After set false (object pooling) - reset their hp
     void OnEnable()
    {
        switch (enemyName)
        {
            case "Boss":
                hp = 3000;
                Debug.Log("Stop");
                Invoke("Stop", 3f);
                break;
            case "L":
                hp = 60;
                break;
            case "M":
                hp = 30;
                break;
            case "S":
                hp = 15;
                break;
        }
    }

    void Update()
    {
        if (enemyName == "Boss")
            return;

        EnemyFire();
        Reload();

    }


    #endregion

    #region Custom_Method

    // Let Boss Stop going down
    void Stop()
    {
        if (!gameObject.activeSelf)
            return;

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.zero;
        Invoke("UsePattern", 2.0f);
    }
    // Boss use patterns
    void UsePattern()
    {
        patternIndex = patternIndex == 3 ? 0 : patternIndex + 1;

        // if patterns back to here, need to make currentPatternCount's value = 0;
        currentPatternCount = 0;
        switch (patternIndex)
        {
            case 0:
                Debug.Log("FireFront");
                FireFront();
                break;
            case 1:
                Debug.Log("FireShot");
                FireShot();
                break;
            case 2:
                Debug.Log("FireArc");
                FireArc();
                break;
            case 3:
                Debug.Log("FireAround");
                FireAround();
                break;
        }
    }

    // Boss Pattens
    void FireFront()
    {
        SoundManager.instance.PLaySE(ShootSound);

        if (hp <= 0) 
            return;
        // Fire Logic
        GameObject bulletR = objectPooling.MakeObject("EnemyBulletA");
        GameObject bulletRR = objectPooling.MakeObject("EnemyBulletA");
        GameObject bulletL = objectPooling.MakeObject("EnemyBulletA");
        GameObject bulletLL = objectPooling.MakeObject("EnemyBulletA");
        bulletR.transform.position = transform.position + Vector3.right * 0.3f;
        bulletRR.transform.position = transform.position + Vector3.right * 0.45f;
        bulletL.transform.position = transform.position + Vector3.left * 0.3f;
        bulletLL.transform.position = transform.position + Vector3.left * 0.45f;

        bulletR.transform.rotation = transform.rotation;
        bulletRR.transform.rotation = transform.rotation;
        bulletL.transform.rotation = transform.rotation;
        bulletLL.transform.rotation = transform.rotation;

        Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();

        rigidR.AddForce(Vector2.down * 5.0f, ForceMode2D.Impulse);
        rigidRR.AddForce(Vector2.down * 5.0f, ForceMode2D.Impulse);
        rigidL.AddForce(Vector2.down * 5.0f, ForceMode2D.Impulse);
        rigidLL.AddForce(Vector2.down * 5.0f, ForceMode2D.Impulse);

        // pattern count increase
        currentPatternCount++;

        if(currentPatternCount < maxPatternCount[patternIndex]  )
        {
            // re-use the same pattern
            Invoke("FireFront", 2.0f);
        }
        else
        {
            // back to the function contains all the patterns and choose pattern.
            Invoke("UsePattern", 3.0f);
        }
    }
    void FireShot()
    {
        SoundManager.instance.PLaySE(ShootSound);

        if (hp <= 0)
            return;
        // fire logic
        for (int i = 0; i < 5; ++i)
        {
            GameObject bullet = objectPooling.MakeObject("BossBulletA");
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            Rigidbody2D rigid2D = bullet.GetComponent<Rigidbody2D>();

            Vector2 dirVec = player.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(0.0f, 2.0f));
            dirVec += ranVec;
            rigid2D.AddForce(dirVec.normalized * 5.0f, ForceMode2D.Impulse);
        }

        // pattern count increase
        currentPatternCount++;

        if (currentPatternCount < maxPatternCount[patternIndex])
        {
            // re-use the same pattern
            Invoke("FireShot", 2.0f);
        }
        else
        {
            // back to the function contains all the patterns and choose pattern.
            Invoke("UsePattern", 3.0f);
        }
    }
    void FireArc()
    {
        SoundManager.instance.PLaySE(ShootSound);

        if (hp <= 0)
            return;
        // fire logic
        GameObject bullet = objectPooling.MakeObject("BossBulletB");
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity; // no rotation

        Rigidbody2D rigid2D = bullet.GetComponent<Rigidbody2D>();

        Vector2 dirVec = new Vector2(Mathf.Sin(currentPatternCount),-1);
        rigid2D.AddForce(dirVec.normalized * 10.0f, ForceMode2D.Impulse);

        // pattern count increase
        currentPatternCount++;

        if (currentPatternCount < maxPatternCount[patternIndex])
        {
            // re-use the same pattern
            Invoke("FireArc", 1.0f);
        }
        else
        {
            // back to the function contains all the patterns and choose pattern.
            Invoke("UsePattern", 3.0f);
        }
    }
    void FireAround()
    {
        SoundManager.instance.PLaySE(ShootSound);

        if (hp <= 0)
            return;
        // fire logic
        int roundNumberA = 30;
        int roundNumberB = 20;
        int roundNumber = currentPatternCount % 2 == 0 ? roundNumberA : roundNumberB; 
        for (int i = 0; i < roundNumber; ++i)
        {
            GameObject bullet = objectPooling.MakeObject("BossBulletA");
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            Rigidbody2D rigid2D = bullet.GetComponent<Rigidbody2D>();

            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / roundNumber), Mathf.Sin(Mathf.PI * 2 * i / roundNumber));
            rigid2D.AddForce(dirVec.normalized * 3.0f, ForceMode2D.Impulse);
        }

        // pattern count increase
        currentPatternCount++;

        if (currentPatternCount < maxPatternCount[patternIndex])
        {
            // re-use the same pattern
            Invoke("FireAround", 0.7f);
        }
        else
        {
            // back to the function contains all the patterns and choose pattern.
            Invoke("UsePattern", 3.0f);
        }
    }

    // Enemy hit by Player
    void OnHit(int damage)
    {
        if (hp <= 0)
            return;

        hp -= damage;

        if (enemyName == "Boss")
        {
            animator.SetTrigger("OnHit");
        }
        else
        {
            //if hit - change sprite
            spriteRenderer.sprite = sprites[1];
            Invoke("ReturnSprite", 0.1f);

        }



        //destroy
        if (hp <= 0)
        {
            SoundManager.instance.PLaySE(DieSound);
            // if Enemy dies, player get scores.
            Player playerLogic = player.GetComponent<Player>();
            // Enemy Score can set from the Prefabs
            playerLogic.score += enemyScore;

            // when enemies dead, drop items - random, if enemy == boss, no item
            int random = enemyName == "Boss" ? 0 : Random.Range(0, 10);
            if (random <= 3) //70%
            {
                // no item
                Debug.Log("No Item");
            }
            else if (random <= 7) //20%
            {
                // coin
                GameObject itemCoin =  objectPooling.MakeObject("ItemCoin");
                itemCoin.transform.position = transform.position;
                //Instantiate(itemCoin, transform.position, itemCoin.transform.rotation);

                // item drop speed
                //Rigidbody2D rigid = itemCoin.GetComponent<Rigidbody2D>();
               // rigid.velocity = Vector2.down * 0.01f;
            }
            else if (random <= 10) // 10%
            {
                // power
                GameObject itemPower = objectPooling.MakeObject("ItemPower");
                itemPower.transform.position = transform.position;
                //Instantiate(itemPower, transform.position, itemPower.transform.rotation);

                // item drop speed
                //Rigidbody2D rigid = itemPower.GetComponent<Rigidbody2D>();
                //rigid.velocity = Vector2.down * 0.01f;

            }

            // object pooling
            gameObject.SetActive(false);
            //Destroy(gameObject);

            // no rotation.
            transform.rotation = Quaternion.identity;
        }
    }

    // back to original sprite
    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];

    }

    void EnemyFire()
    {
        //if reloading time is not max, cannot fire.
        if (currentReloadingTime < maxReloadingTime)
            return;

        if (enemyName == "L")
        {
            SoundManager.instance.PLaySE(ShootSound);
            //generate bullets, Instantiate(Prefab, Position where creates, Rotation)
            // GameObject bullet = Instantiate(EnemyBulletA, transform.position, transform.rotation);
            GameObject bullet = objectPooling.MakeObject("EnemyBulletA");
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            Rigidbody2D rigid2D = bullet.GetComponent<Rigidbody2D>();

            //Vector between enemies and player
            Vector3 dirVec = player.transform.position - transform.position;

            rigid2D.AddForce(dirVec.normalized * 3.0f, ForceMode2D.Impulse);
        }
        else if (enemyName == "M") // shoot 2 kinds of bullets
        {
            SoundManager.instance.PLaySE(ShootSound);
            //generate bullets, Instantiate(Prefab, Position where creates, Rotation)
            //GameObject bulletR = Instantiate(EnemyBulletB, transform.position + Vector3.right*0.3f, transform.rotation);
            GameObject bulletR = objectPooling.MakeObject("EnemyBulletB");
            bulletR.transform.position = transform.position + Vector3.right * 0.3f;
            bulletR.transform.rotation = transform.rotation;

            Rigidbody2D rigid1 = bulletR.GetComponent<Rigidbody2D>();
            //Vector between enemies and player
            Vector3 dirVec = player.transform.position - (transform.position + Vector3.right * 0.3f);
            rigid1.AddForce(dirVec.normalized * 5.0f, ForceMode2D.Impulse);

            //generate bullets, Instantiate(Prefab, Position where creates, Rotation)
            //GameObject bulletL = Instantiate(EnemyBulletB, transform.position + Vector3.left * 0.3f, transform.rotation);
            GameObject bulletL = objectPooling.MakeObject("EnemyBulletB");
            bulletL.transform.position = transform.position + Vector3.left * 0.3f;
            bulletL.transform.rotation = transform.rotation;

            Rigidbody2D rigid2 = bulletL.GetComponent<Rigidbody2D>();
            //Vector between enemies and player
            Vector3 dirVec2 = player.transform.position - (transform.position + Vector3.left * 0.3f);
            rigid2.AddForce(dirVec.normalized * 5.0f, ForceMode2D.Impulse);
        }

        //after shot, reset reloading 
        currentReloadingTime = 0;
    }

    //Reload
    void Reload()
    {
        currentReloadingTime += Time.deltaTime;
    }
    #endregion

    #region Trigger_Method
    // Enemies and Player Bullets cannot go out of the Border
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BulletBorder" && enemyName != "Boss")
        {
            // if enemy go out of the screen - object pooling
            gameObject.SetActive(false);
            transform.rotation = Quaternion.identity;

        }
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            // if enemy hit bullet
            PlayerBullet playerbullet = collision.gameObject.GetComponent<PlayerBullet>();
            OnHit(playerbullet.damage);

            //delete player bullet - object pooling
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }

    #endregion
}
