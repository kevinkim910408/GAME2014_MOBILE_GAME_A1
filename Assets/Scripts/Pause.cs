using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject PausePanel;

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
    public void Setting()
    {
        
    }
}
