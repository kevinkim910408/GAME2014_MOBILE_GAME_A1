using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage;

     void OnTriggerEnter2D(Collider2D collision)
    {
        //if gmaobject(bullets) touch the border
        if(collision.gameObject.tag == "BulletBorder")
        {
            Destroy(gameObject); //destroy bullets
        }
    }
}
