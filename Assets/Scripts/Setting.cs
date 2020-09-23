using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: Setting.cs
/// Date last Modified: 2020-09-23
/// Program description
///  - vision Setting panel
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// </summary>

public class Setting : MonoBehaviour
{
    [SerializeField]
    GameObject SettingPanel;

    int counter_SettingPanel;

    void Awake()
    {
        SettingPanel.gameObject.SetActive(false);
    }
    public void ShowBtn()
    {
        counter_SettingPanel++;
        if (counter_SettingPanel % 2 == 1)
        {
            SettingPanel.gameObject.SetActive(true);
        }
    }
    public void BackBtn()
    {
        counter_SettingPanel++;
        if (counter_SettingPanel % 2 == 0)
        {
            SettingPanel.gameObject.SetActive(false);
        }
    }
}
