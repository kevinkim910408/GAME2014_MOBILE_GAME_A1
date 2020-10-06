using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: Setting.cs
/// Date last Modified: 2020-10-07
/// Program description
///  - vision Setting panel
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// 2020-10-07: inline comments, make code looks clear, removed unnecessary codes
/// </summary>

public class Setting : MonoBehaviour
{
    #region Variables

    // Get a Panel
    [SerializeField]
    GameObject SettingPanel;

    // for Toggling the Setting Panel
    int counter_SettingPanel;

    #endregion

    #region Unity_Method
    void Awake()
    {
        // At Start, setting is not activated.
        SettingPanel.gameObject.SetActive(false);
    }

    #endregion

    #region Custom_Method

    // Toggle the Setting button 
    public void ShowBtn()
    {
        counter_SettingPanel++;
        if (counter_SettingPanel % 2 == 1)
        {
            SettingPanel.gameObject.SetActive(true);
        }
    }

    // Back button in the setting
    public void BackBtn()
    {
        counter_SettingPanel++;
        if (counter_SettingPanel % 2 == 0)
        {
            SettingPanel.gameObject.SetActive(false);
        }
    }
    #endregion
}
