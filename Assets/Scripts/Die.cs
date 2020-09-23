using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: Die.cs
/// Date last Modified: 2020-09-23
/// Program description
///  - managing player's after death.
///  - UI appear when user press escape key. --> will change to when player die.
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// </summary>

public class Die : MonoBehaviour
{
    [SerializeField]
    GameObject DiePanel;

    int counter_DiePanel;

    void Awake()
    {
        DiePanel.gameObject.SetActive(false);
    }

}
