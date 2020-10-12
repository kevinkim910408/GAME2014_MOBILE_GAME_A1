using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: BackgroundScroller.cs
/// Date last Modified: 2020-10-12
/// Program description
///  - Background Scrolling
///  
/// Revision History
/// 2020-10-12: Made script, background scrolling
/// </summary>
/// 

public class BackgroundScroller : MonoBehaviour
{
    // background moving speed
    [SerializeField]
    float backgroundSpeed;

    // Reset Position
    [SerializeField]
    float positionX;
    [SerializeField]
    float positionY;
    [SerializeField]
    float positionZ;

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        //var = auto in c++
        var newPosition = new Vector3(0.0f, backgroundSpeed, 0.0f);
        transform.position -= newPosition;
    }

    //if bacground hit this, reset background position
    private void Reset()
    {
        transform.position = new Vector3(positionX, positionY, positionZ);
    }

    //check bounds with background
    private void CheckBounds()
    {
        // check bottom bounds
        if (transform.position.y <= -10.0f)
        {
            Reset();
        }
    }

}
