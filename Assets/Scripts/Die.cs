using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: Die.cs
/// Date last Modified: 2020-09-23
/// Program description
///  - managing player's after death.
///  - UI appear when user press space key. --> will change to when player die.
///  - Button - back to main menu
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// </summary>

public class Die : MonoBehaviour
{
    [SerializeField]
    GameObject DiePanel;

    int counter_DiePanel;
    bool isPause = false;

    void Awake()
    {
        DiePanel.gameObject.SetActive(false);
    }
     void Update()
    {
        DieTemp();
    }

    
    void DieTemp() //will be deleted function.
    {
        if (Input.GetKeyDown(KeyCode.Space))
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

    public void MainMenu()
    {
            SceneManager.LoadScene("Scenes/TitleScene");
    }

}
