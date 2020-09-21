using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBtn : MonoBehaviour
{
    public void PlayGame()
    {
        //call loading menu
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

}
