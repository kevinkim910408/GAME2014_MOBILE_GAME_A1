using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public int hp;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    [SerializeField]
    Sprite[] sprites;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * moveSpeed;
    }

    void OnHit(int damage)
    {
        hp -= damage;
        spriteRenderer.sprite = sprites[1];

        Invoke("ReturnSprite",0.1f);

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BulletBorder")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            PlayerBullet playerbullet = collision.gameObject.GetComponent<PlayerBullet>();
            OnHit(playerbullet.damage);

            Destroy(collision.gameObject);
        }
    }

}
