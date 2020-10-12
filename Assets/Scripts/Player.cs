using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: Player.cs
/// Date last Modified: 2020-10-11
/// Program description
///  - Contains basic player needs - speeds, animation, bullets.
///  - movement
///  - if player gets energy - power up
///  - borders - player cannot go out of the screen.
///  - fire reloading time.
///  - 
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// 2020-10-07: inline comments, make code looks clear, removed unnecessary codes
/// 2020-10-11: player can get items.
/// </summary> 
public class Player : MonoBehaviour
{
    #region Variables

    // Speeds
    [SerializeField]                        //SerializeField makes 'private' to 'public', but safe.
    float moveSpeed = 5.0f;
    [SerializeField]
    float bulletSpeed = 10.0f;
    [SerializeField]
    float bombSpeed = 10.0f;

    //for player animation
    Animator animator;

    //for player touch the screen border
    bool touchTop = false;
    bool touchBottom = false;
    bool touchRight = false;
    bool touchLeft = false;

    //Player projectiles
    [SerializeField]
    GameObject playerBullet;
    [SerializeField]
    GameObject playerBomb;

    //delay player's firing
    [SerializeField]
    float maxReloadingTime = 0.5f;
    [SerializeField]
    float currentReloadingTime;

    // To use Player Respawning
    public EnemyManager manager;

    // player life and score -  for UI
    public int life;
    public int score;

    // even player is hit 2 attacks at the same time, life decreases only one.
    public bool isHit;
    
 
    // about items
    public int curentPower;
    public int maxPower;

    // object pooling
    public ObjectPooling objectPooling; 

    #endregion

    #region Unity_Method
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerFire();
        Reload();

    }

    #endregion

    #region Custom_Method
    void PlayerMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // GetAxis - soft movement
        float moveY = Input.GetAxisRaw("Vertical"); // GetAxisRaw - instantly move

        //if player touch the screen - X-axis
        if ((touchRight && moveX == 1) || (touchLeft && moveX == -1))
        {
            // make movement 0
            moveX = 0;
        }
        //if player touch the screen - Y-axis
        if ((touchTop && moveY == 1) || (touchBottom && moveY == -1))
        {
            // make movement 0
            moveY = 0;
        }

        //2D game, no Z-axis.
        Vector3 movement = new Vector3(moveX, moveY, 0.0f) * moveSpeed * Time.deltaTime;
        Vector3 currentPosition = transform.position;

        //move
        transform.position = currentPosition + movement;

        //animation - x-axis 
        if (Input.GetButtonDown("Horizontal") ||
                Input.GetButtonUp("Horizontal"))
        {
            animator.SetInteger("Value", (int)moveX);
        }
    }

    void PlayerFire()
    {
        // Mouse Left Click
        if (!Input.GetButton("Fire1"))
            return;
            
        //if reloading time is not max, cannot fire.
        if (currentReloadingTime < maxReloadingTime)
            return;

        switch (curentPower)
        {
            // energy = 1
            case 0:
            case 1:
            case 2:
                //generate bullets, Instantiate(Prefab, Position where creates, Rotation)
                // GameObject bullet = Instantiate(playerBullet, transform.position, transform.rotation);
                GameObject bullet = objectPooling.MakeObject("PlayerBulletA");
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;

                 //to add force
                Rigidbody2D rigid2D = bullet.GetComponent<Rigidbody2D>();
                rigid2D.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                break;

            // energy = 3
            case 3:
            case 4:
                //GameObject bulletRight = Instantiate(playerBullet, transform.position + Vector3.right * 0.15f, transform.rotation);
                //GameObject bulletLeft = Instantiate(playerBullet, transform.position + Vector3.left * 0.1f, transform.rotation);

                GameObject bulletRight = objectPooling.MakeObject("PlayerBulletA");
                GameObject bulletLeft = objectPooling.MakeObject("PlayerBulletA");
                bulletRight.transform.position = transform.position + Vector3.right * 0.15f;
                bulletLeft.transform.position = transform.position + Vector3.left * 0.1f;
                bulletRight.transform.rotation = transform.rotation;
                bulletLeft.transform.rotation = transform.rotation;

                Rigidbody2D rigid2DRight = bulletRight.GetComponent<Rigidbody2D>();
                Rigidbody2D rigid2DLeft = bulletLeft.GetComponent<Rigidbody2D>();
                rigid2DRight.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                rigid2DLeft.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                break;

            // energy = 5
            case 5:
            case 6:
                //GameObject bomb = Instantiate(playerBomb, transform.position, transform.rotation);
                GameObject bomb = objectPooling.MakeObject("PlayerBulletB");
                bomb.transform.position = transform.position;
                bomb.transform.rotation = transform.rotation;

                Rigidbody2D rigid2D_bomb = bomb.GetComponent<Rigidbody2D>();
                rigid2D_bomb.AddForce(Vector2.up * bombSpeed, ForceMode2D.Impulse);
                break;

            //energt = 7
            case 7:
            case 8:
            case 9:
                //GameObject bomb2 = Instantiate(playerBomb, transform.position, transform.rotation);
                //GameObject bulletRight2 = Instantiate(playerBullet, transform.position + Vector3.right * 0.3f, transform.rotation);
                //GameObject bulletLeft2 = Instantiate(playerBullet, transform.position + Vector3.left * 0.25f, transform.rotation);
                GameObject bulletRight2 = objectPooling.MakeObject("PlayerBulletA");
                GameObject bulletLeft2 = objectPooling.MakeObject("PlayerBulletA");
                GameObject bomb2 = objectPooling.MakeObject("PlayerBulletB");

                bomb2.transform.position = transform.position;
                bulletRight2.transform.position = transform.position + Vector3.right * 0.3f;
                bulletLeft2.transform.position = transform.position + Vector3.left * 0.25f;

                bomb2.transform.rotation = transform.rotation;
                bulletRight2.transform.rotation = transform.rotation;
                bulletLeft2.transform.rotation = transform.rotation;

                Rigidbody2D rigid2D_bomb2 = bomb2.GetComponent<Rigidbody2D>();
                Rigidbody2D rigid2DRight2 = bulletRight2.GetComponent<Rigidbody2D>();
                Rigidbody2D rigid2DLeft2 = bulletLeft2.GetComponent<Rigidbody2D>();
                rigid2D_bomb2.AddForce(Vector2.up * bombSpeed, ForceMode2D.Impulse);
                rigid2DRight2.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                rigid2DLeft2.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                break;
            case 10:
                //GameObject bomb3 = Instantiate(playerBomb, transform.position, transform.rotation);
                //GameObject bulletRight3 = Instantiate(playerBullet, transform.position + Vector3.right * 0.3f, transform.rotation);
                //GameObject bulletLeft3 = Instantiate(playerBullet, transform.position + Vector3.left * 0.25f, transform.rotation);
                //GameObject bulletRight4 = Instantiate(playerBullet, transform.position + Vector3.right * 0.6f, transform.rotation);
                //GameObject bulletLeft4 = Instantiate(playerBullet, transform.position + Vector3.left * 0.5f, transform.rotation);

                GameObject bulletRight3 = objectPooling.MakeObject("PlayerBulletA");
                GameObject bulletRight4 = objectPooling.MakeObject("PlayerBulletA");
                GameObject bulletLeft3 = objectPooling.MakeObject("PlayerBulletA");
                GameObject bulletLeft4 = objectPooling.MakeObject("PlayerBulletA");
                GameObject bomb3 = objectPooling.MakeObject("PlayerBulletB");
                bomb3.transform.position = transform.position;
                bulletRight3.transform.position = transform.position + Vector3.right * 0.3f;
                bulletRight4.transform.position = transform.position + Vector3.left * 0.25f;
                bulletLeft3.transform.position = transform.position + Vector3.right * 0.6f;
                bulletLeft4.transform.position = transform.position + Vector3.left * 0.5f;

                bomb3.transform.rotation = transform.rotation;
                bulletRight3.transform.rotation = transform.rotation;
                bulletRight4.transform.rotation = transform.rotation;
                bulletLeft3.transform.rotation = transform.rotation;
                bulletLeft4.transform.rotation = transform.rotation;

                Rigidbody2D rigid2D_bomb3 = bomb3.GetComponent<Rigidbody2D>();
                Rigidbody2D rigid2DRight3 = bulletRight3.GetComponent<Rigidbody2D>();
                Rigidbody2D rigid2DLeft3 = bulletLeft3.GetComponent<Rigidbody2D>();
                Rigidbody2D rigid2DRight4 = bulletRight4.GetComponent<Rigidbody2D>();
                Rigidbody2D rigid2DLeft4 = bulletLeft4.GetComponent<Rigidbody2D>();

                rigid2D_bomb3.AddForce(Vector2.up * bombSpeed, ForceMode2D.Impulse);
                rigid2DRight3.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                rigid2DLeft3.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                rigid2DRight4.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                rigid2DLeft4.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                break;

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

    //when player hit the screen border
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScreenBorder") // if the tag is screenborder
        {
            switch (collision.gameObject.name) // check the name of the objects
            {
                case "top":
                    touchTop = true;
                    break;
                case "bottom":
                    touchBottom = true;
                    break;
                case "right":
                    touchRight = true;
                    break;
                case "left":
                    touchLeft = true;
                    break;
            }
        }
        // player is shot by enemy (die)
        else if ((collision.gameObject.tag == "Enemy") ||(collision.gameObject.tag == "EnemyBullet"))
        {
            if (isHit)
                return;

            isHit = true;
            life--;
            manager.UpdateLife(life);

            if(life == 0)
            {
                manager.GameOver();
            }
            else
            {
                manager.RespawnPlayer();
            }
            gameObject.SetActive(false);
            // Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);

        }

        //player gets items
        else if ((collision.gameObject.tag == "Item") || (collision.gameObject.tag == "EnemyBullet"))
        {
            Item item = collision.gameObject.GetComponent<Item>();
            switch (item.itemType)
            {
                case "Coin":
                    score += 1500;
                    break;

                case "Power":
                    if(curentPower == maxPower)
                    {
                        score += 1000;
                    }
                    else
                    {
                        curentPower++;
                    }
                    break;
            }
            // destroy items -- object pooling
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }

    // player exit from the screen border
     void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ScreenBorder")
        {
            switch (collision.gameObject.name)
            {
                case "top":
                    touchTop = false;
                    break;
                case "bottom":
                    touchBottom = false;
                    break;
                case "right":
                    touchRight = false;
                    break;
                case "left":
                    touchLeft = false;
                    break;
            }
        }
    }

    
}
