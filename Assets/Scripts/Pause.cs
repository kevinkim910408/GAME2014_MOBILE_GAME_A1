using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: Die.cs
/// Date last Modified: 2020-10-07
/// Program description
///  - Setting: menu button, resume button
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// 2020-09-29: Delete Setting for now.
/// 2020-10-07: inline comments, make code looks clear, removed unnecessary codes
/// </summary>
/// 
public class Pause : MonoBehaviour
{
    #region Variables
    // Get Panels
    [SerializeField]
    GameObject PausePanel = null;
    [SerializeField]
    GameObject SettingPanel;

    //int counter_SettingPanel;

    // At Start, not pause the game
    bool isPause = false;

    #endregion

    #region Unity_Method
    void Awake()
    {
        // At Start, not pause the game
        PausePanel.gameObject.SetActive(false);
    }
    #endregion

    #region Custom_Method

    //Button for the Pause
    public void PauseButton()
    {
        if (!isPause)
        {
            Time.timeScale = 0;
            isPause = true;
        }
        // Active Pause Button
        PausePanel.gameObject.SetActive(true);

    }

    // Option no.1 in the pause button
    public void MainMenu()
    {
        SceneManager.LoadScene("Scenes/TitleScene");
        if (isPause)
        {
            Time.timeScale = 1;
            isPause = false;
        }
    }

    // Option no.2 in the pause button
    public void Resume()
    {
        if (isPause)
        {
            Time.timeScale = 1;
            isPause = false;
        }
        PausePanel.gameObject.SetActive(false);
    }
    #endregion

}
