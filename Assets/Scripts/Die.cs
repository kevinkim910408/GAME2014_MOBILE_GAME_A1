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
///  - managing player's after death.
///  - UI appear when user press space key. --> will change to when player die.
///  - Button - back to main menu
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// 2020-09-29: Die Key -> Die button
/// 2020-10-07: inline comments, make code looks clear, removed unnecessary codes
/// </summary>

public class Die : MonoBehaviour
{
    #region Variables

    // for pop-up die event (panel)
    [SerializeField]
    GameObject DiePanel;

    //int counter_DiePanel; 

    // Only Pause when player dead
    bool isPause = false;

    #endregion

    #region Unity_Method

    void Awake()
    {
        // At first, there is no die event
        DiePanel.gameObject.SetActive(false);
    }
     void Update()
    {
        //DieTemp();
    }

    #endregion

    #region Custom_Method

    // Die Button - will be removed
    public void DieButton()
    {
        if (!isPause)
        {
            Time.timeScale = 0;
            isPause = true;
        }
        DiePanel.gameObject.SetActive(true);

    }


    /* //Spawn Die event with a button - not available now
     
    public void DieTemp() 
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            counter_DiePanel++;
            if (counter_DiePanel % 2 == 1)
            {
                if (!isPause)
                {
                    Time.timeScale = 0;
                    isPause = true;
                }
                DiePanel.gameObject.SetActive(true);
            }
            if (counter_DiePanel % 2 == 0)
            {
                if (isPause)
                {
                    Time.timeScale = 1;
                    isPause = false;
                }
                DiePanel.gameObject.SetActive(false);
            }

        }
    }
    */

    // Option no.1 in the die event
    public void MainMenu()
    {
        SceneManager.LoadScene("Scenes/TitleScene");
        if (isPause)
        {
            Time.timeScale = 1;
            isPause = false;
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
