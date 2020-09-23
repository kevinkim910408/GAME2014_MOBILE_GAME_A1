using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: TitleBtn.cs
/// Date last Modified: 2020-09-23
/// Program description
///  - Click the play -> move to loading scene
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// </summary>
/// 
public class TitleBtn : MonoBehaviour
{
    public void PlayGame()
    {
        //call loading menu
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

}
