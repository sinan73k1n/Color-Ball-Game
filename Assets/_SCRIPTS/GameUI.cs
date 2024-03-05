using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Button _btnSettings;


    private void Awake()
    {
        SetButtons();
    }

    private void SetButtons()
    {
        _btnSettings.onClick.AddListener(() =>
        {
            MusicPlayer.instance.Click();
            SceneManager.LoadScene(0);
        });

      

    }
}
