using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: Enmey.cs
/// Date last Modified: 2020-10-07
/// Program description
///  - This script is only for enemies. It contains enemies hp, and movespeed. Also contains enemies sprites to change when enemies are hit by player.
///  - if Enemies and the bullets hit the border --> destroy.
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// 2020-10-07: inline comments + make code looks clear
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
    Rigidbody2D rigid;

    // Enemies' sprites
    [SerializeField]
    Sprite[] sprites = null;

    #endregion

    #region Unity_Method
    private void Awake()
    {
        // GetComponents
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();

        // Initialize Enemies' velocity
        rigid.velocity = Vector2.down * moveSpeed;
    }


    #endregion

    #region Custom_Method

    // Enemy hit by Player
    void OnHit(int damage)
    {
        hp -= damage;
        //if hit - change sprite
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite",0.1f);

        //destroy
        if(hp <= 0)
        {
            Destroy(gameObject);
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
            // if enemy go out of the screen
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            // if enemy hit bullet
            PlayerBullet playerbullet = collision.gameObject.GetComponent<PlayerBullet>();
            OnHit(playerbullet.damage);

            //delete player bullet 
            Destroy(collision.gameObject);
        }
    }

}
