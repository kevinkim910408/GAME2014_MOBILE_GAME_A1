using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: Die.cs
/// Date last Modified: 2020-10-16
/// Program description
///  - managing player's after death.
///  - UI appear when user press space key. --> will change to when player die.
///  - Button - back to main menu
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// 2020-09-29: Die Key -> Die button
/// 2020-10-07: inline comments, make code looks clear, removed unnecessary codes, 
/// 2020-10-07: only use for options after die.
/// 2020-10-16: turn off game scene background music when player move to main menu
/// </summary>

public class Die : MonoBehaviour
{
    #region Variables
    // Only Pause when player dead
    bool isPause = false;

    #endregion

    #region Unity_Method
    private void Start()
    {
        // Pause if game over
        if (!isPause)
        {
            Time.timeScale = 0;
            isPause = true;
        }
    }

    #endregion

    #region Custom_Method
    // Option no.1 in the die event
    public void MainMenu()
    {
        SceneManager.LoadScene("Scenes/TitleScene");
        if (isPause)
        {
            Time.timeScale = 1;
            isPause = false;
            //turn off game scene background music
            SoundManager.instance.StopAllSE();
        }
    }

    // Option no.2 in the die event
    public void Retry()
    {
        SceneManager.LoadScene("Scenes/GameScene");
        if (isPause)
        {
            Time.timeScale = 1;
            isPause = false;
        }
    }
    #endregion
}
