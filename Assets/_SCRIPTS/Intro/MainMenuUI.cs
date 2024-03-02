using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] Button _btnPlay, _btnSound, _btnMusic, _btnAbout,_btnAboutX, _btnExit, _btnReset, _btnResetNo, _btnResetYes;
    [SerializeField] Sprite _sptMusicOn, _sptMusicOff, _sptSoundOn, _sptSoundOff;
    [SerializeField] Image _imgBtnMusic, _imgBtnSound;
    [SerializeField] GameObject _panelAbout, _panelReset;
    [SerializeField] TMP_Text _txtLevel;

    private void Awake()
    {

        Application.targetFrameRate = 60;
        SetButtons();
    }
    private void Start()
    {
        SetValues();
    }

    private void SetValues()
    {
        _panelAbout.SetActive(false);
        _panelReset.SetActive(false);
        SetSoundSprite();
        SetMusicSprite();
        _txtLevel.text = PlayerPrefs.GetInt("Level", 1).ToString();

    }

    private void SetButtons()
    {
        _btnPlay.onClick.AddListener(() =>
        {
            MusicPlayer.instance.Click();
          //  SceneManager.LoadScene(PlayerPrefs.GetInt("Level", 1));
            SceneManager.LoadScene(1);
        });

        _btnMusic.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("Music", PlayerPrefs.GetInt("Music",1) == 1 ? 0 : 1);
            SetMusicSprite();
        });
        _btnSound.onClick.AddListener(() =>
        {
             
            PlayerPrefs.SetInt("Sound", PlayerPrefs.GetInt("Sound",1) == 1 ? 0 : 1);
            SetSoundSprite();
            if (PlayerPrefs.GetInt("Sound", 1) == 1) MusicPlayer.instance.Click();
        });
        _btnAbout.onClick.AddListener(() =>
        {
            MusicPlayer.instance.Click();
            _panelAbout.SetActive(true);
        });
        _btnAboutX.onClick.AddListener(() =>
        {
            MusicPlayer.instance.Click();
            _panelAbout.SetActive(false);
        });
        _btnReset.onClick.AddListener(() =>
        {
            MusicPlayer.instance.Click();
            _panelReset.SetActive(true);
        });
        _btnResetNo.onClick.AddListener(() =>
        {
            MusicPlayer.instance.Click();
            _panelReset.SetActive(false);
        });

        _btnResetYes.onClick.AddListener(() =>
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(0);
        });
        _btnExit.onClick.AddListener(() =>
        {
            Application.Quit();
        });

    }

    void SetMusicSprite()
    {
        bool temp = PlayerPrefs.GetInt("Music", 1) == 1;
        _imgBtnMusic.sprite = temp == true ? _sptMusicOn : _sptMusicOff;
        MusicPlayer.instance.RefreshVolume();
    }

    void SetSoundSprite()
    {
        bool temp = PlayerPrefs.GetInt("Sound", 1) == 1;
        _imgBtnSound.sprite = temp == true ? _sptSoundOn : _sptSoundOff;
        MusicPlayer.instance.RefreshVolume();
    }
}
