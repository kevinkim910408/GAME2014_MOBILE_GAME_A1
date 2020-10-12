 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: item.cs
/// Date last Modified: 2020-10-12
/// Program description
///  - Manage all the items in game - power up, coins
///  
/// Revision History
/// 2020-10-11: Made script, add type,  
/// 2020-10-12: make codes clean
/// </summary>
/// 

public class Item : MonoBehaviour
{
    #region Variables
    public string itemType;
    Rigidbody2D rigid;

    #endregion

    #region Unity_Method
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * 0.01f;
    }


    void OnEnable()
    {
       // rigid.velocity = Vector2.down * 0.01f;
    }

    #endregion

}
