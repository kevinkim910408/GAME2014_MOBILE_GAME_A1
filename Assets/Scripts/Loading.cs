using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: Loading.cs
/// Date last Modified: 2020-09-23
/// Program description
///  - after 3 secs, move to play game scene
///  - add a slider to let users know the progress of loading
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// </summary>
/// 
public class Loading : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    bool IsDone = false;
    float fTime = 0.0f;
    AsyncOperation async_operation;

    void Start()
    {
        StartCoroutine(StartLoad("Scenes/GameScene"));
    }

    void Update()
    {
        fTime += Time.deltaTime;
        slider.value = fTime;

        if (fTime >= 3.0f)
        {
            fTime = 0.0f;
            async_operation.allowSceneActivation = true;
        }
    }

    public IEnumerator StartLoad(string strSceneName)
    {
        async_operation = SceneManager.LoadSceneAsync(strSceneName);
        async_operation.allowSceneActivation = false;

        if (IsDone == false)
        {
            IsDone = true;

            while (async_operation.progress < 0.9f)
            {
                slider.value = async_operation.progress;

                yield return true;
            }
        }
    }
}

