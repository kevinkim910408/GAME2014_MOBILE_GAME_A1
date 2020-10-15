using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: SoundManager.cs
/// Date last Modified: 2020-10-15
/// Program description
///  - Manage all the sounds
///  
/// Revision History
/// 2020-10-15: manage bgm, shooting, and die sounds
/// </summary>
/// 


[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance; 

    [SerializeField]
    Sound[] bgmSounds;

    [SerializeField]
    Sound[] sfxSounds;

    [SerializeField]
    AudioSource bgmPlayer;

    [SerializeField]
    AudioSource[] sfxPlayer;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlayBGM();
    }

    public void PlaySE(string soundName)
    {
        for (int i = 0; i < sfxSounds.Length; ++i)
        {
            if(soundName == sfxSounds[i].soundName)
            {
                for(int j = 0; j < sfxPlayer.Length; ++j)
                {
                    if (!sfxPlayer[j].isPlaying)
                    {
                        sfxPlayer[j].clip = sfxSounds[j].clip;
                        sfxPlayer[j].Play();
                        return;
                    }
                }
                Debug.Log(" all the sfx are using");
                return;
            }
        }
        Debug.Log("no sound effects");
    }

    public void PlayBGM()
    {
        int random = Random.Range(0, 3);
        bgmPlayer.clip = bgmSounds[random].clip;
        bgmPlayer.Play();
    }


}
