using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundImg : MonoBehaviour
{
    private Color randomColor;


    void Start()
    {
        randomColor = new Color(Random.Range(0.1f, 1), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
        GetComponent<SpriteRenderer>().color = randomColor;
    }

}
