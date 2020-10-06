using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: TitleBtn.cs
/// Date last Modified: 2020-10-07
/// Program description
///  - Click the play -> move to loading scene
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// 2020-10-07: inline comments, make code looks clear, removed unnecessary codes
/// </summary>
/// 
public class TitleBtn : MonoBehaviour
{
    #region Custom_Method

    // Load the title Scene
    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/LoadingScene");
    }

    #endregion

}
