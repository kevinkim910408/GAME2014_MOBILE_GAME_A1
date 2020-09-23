using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: PlayerBullet.cs
/// Date last Modified: 2020-09-23
/// Program description
///  - contains damage
///  - if bullet out of the screen (hit the border), destroy
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// </summary>
/// 
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
