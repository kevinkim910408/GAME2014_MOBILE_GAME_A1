﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: Enmey.cs
/// Date last Modified: 2020-10-12
/// Program description
///  - This script is only for enemies. It contains enemies hp, and movespeed. Also contains enemies sprites to change when enemies are hit by player.
///  - if Enemies and the bullets hit the border --> destroy.
///  - Enmey can fire bullets to player
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// 2020-10-07: inline comments + make code looks clear, Enmey can fire
/// 2020-10-12: Enemy drops items
/// </summary>
/// 
public class Enemy : MonoBehaviour
{
    #region Variables
    // Basic stats for the enemies
    public float moveSpeed;
    public int hp;

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

    // Enemy's score
    public int enemyScore;

    public ObjectPooling objectPooling;

    #endregion

    #region Unity_Method
    private void Awake()
    {
        // GetComponents
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // After set false (object pooling) - reset their hp
    private void OnEnable()
    {
        switch (enemyName)
        {
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
        EnemyFire();
        Reload();

    }


    #endregion

    #region Custom_Method

    // Enemy hit by Player
    void OnHit(int damage)
    {
        if (hp <= 0)
            return;

        hp -= damage;
        //if hit - change sprite
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite",0.1f);

        //destroy
        if(hp <= 0)
        {
            // if Enemy dies, player get scores.
            Player playerLogic = player.GetComponent<Player>();
            // Enemy Score can set from the Prefabs
            playerLogic.score += enemyScore;

            // when enemies dead, drop items - random
            int random = Random.Range(0, 10);
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
    #endregion

    // Enemies and Player Bullets cannot go out of the Border
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BulletBorder")
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

    void EnemyFire()
    {
        //if reloading time is not max, cannot fire.
        if (currentReloadingTime < maxReloadingTime)
            return;

        if(enemyName == "L")
        {
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

}
