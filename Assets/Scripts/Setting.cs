using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
