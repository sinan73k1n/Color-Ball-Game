using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private TMP_Text currentLevelText, nextLevelText;
    private Image fill;

    private int level;
    private float startDistance, distance;

    private GameObject player, finish, hand;
    private TextMesh levelNumber;
    private PlayerController playerController;


    void Awake()
    {
        currentLevelText = GameObject.Find("CurrentLevelText").GetComponent<TMP_Text>();
        nextLevelText = GameObject.Find("NextLevelText").GetComponent<TMP_Text>();
        fill = GameObject.Find("Fill").GetComponent<Image>();

        hand = GameObject.Find("Hand");
        player = GameObject.Find("Player");
        finish = GameObject.Find("Finish");
        playerController = player.GetComponent<PlayerController>();

        levelNumber = GameObject.Find("LevelNumberTextMesh").GetComponent<TextMesh>();
    }

    void Start()
    {
        level = PlayerPrefs.GetInt("Level",1);
        levelNumber.text = "Level " + level;

        nextLevelText.text = level + 1+"";
        currentLevelText.text = level.ToString();

        startDistance = Vector3.Distance(player.transform.position, finish.transform.position);
    }

    private void Update()
    {
        FillDistance();
    }

    void FillDistance()
    {
        distance = Vector3.Distance(player.transform.position, finish.transform.position);

        if (player.transform.position.z < finish.transform.position.z && !playerController.gameOver)
            fill.fillAmount = 1 - (distance / startDistance);
    }

    public void RemoveUI()
    {
        hand.SetActive(false);
    }
}
