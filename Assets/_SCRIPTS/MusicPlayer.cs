using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    
    public static MusicPlayer instance;
    [SerializeField] AudioSource myMusicPlayer,mySoundPlayer;
    [SerializeField] AudioClip _click, _finish;

    bool SoundOn;
    private void Awake()
    {
        if (FindObjectsOfType<MusicPlayer>().Length>1)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
            myMusicPlayer = GetComponent<AudioSource>();
           
            RefreshVolume();
        }
        

    }

    public void RefreshVolume()
    {
        myMusicPlayer.mute = PlayerPrefs.GetInt("Music", 1) != 1;
        SoundOn = PlayerPrefs.GetInt("Sound", 1) == 1;
    }

    public void Click()
    {
        if (!SoundOn) return;
        mySoundPlayer.PlayOneShot(_click);
    }
    public void Finish()
    {
        if (!SoundOn) return;
        mySoundPlayer.PlayOneShot(_finish);
    }

}
