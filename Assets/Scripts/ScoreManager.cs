﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowScore(int score)
    {
        gameObject.SetActive(true);
        GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
