 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: item.cs
/// Date last Modified: 2020-10-11
/// Program description
///  - Manage all the items in game - power up, coins
///  
/// Revision History
/// 2020-10-11: Made script, add type,  
/// </summary>
/// 

public class Item : MonoBehaviour
{
    public string itemType;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
