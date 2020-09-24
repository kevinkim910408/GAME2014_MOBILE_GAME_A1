using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SettingPanel.gameObject.SetActive(false);

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
