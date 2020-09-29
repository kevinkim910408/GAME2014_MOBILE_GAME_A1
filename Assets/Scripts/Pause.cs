using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: Die.cs
/// Date last Modified: 2020-09-29
/// Program description
///  - Setting: menu button, resume button
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// 2020-09-29: Delete Setting for now.
/// </summary>
/// 
public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject PausePanel;
    [SerializeField]
    GameObject SettingPanel;

    int counter_SettingPanel;

    bool isPause = false;

    void Awake()
    {
        PausePanel.gameObject.SetActive(false);
       

    }

    public void PauseButton()
    {
        if (!isPause)
        {
            Time.timeScale = 0;
            isPause = true;
        }
        PausePanel.gameObject.SetActive(true);

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Scenes/TitleScene");
        if (isPause)
        {
            Time.timeScale = 1;
            isPause = false;
        }
    }
    public void Resume()
    {
        if (isPause)
        {
            Time.timeScale = 1;
            isPause = false;
        }
        PausePanel.gameObject.SetActive(false);
    }
   
}
