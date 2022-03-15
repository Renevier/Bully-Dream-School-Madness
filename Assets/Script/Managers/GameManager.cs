using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI timerTxt;
    [SerializeField] TextMeshProUGUI coinTxt;

    private float timerSecondes = 0;
    private int nbCoins = 0;

    private void Update()
    {
        coinTxt.text = nbCoins.ToString();

        Timer();
    }

    private void Timer()
    {
        timerTxt.text = ((int)timerSecondes).ToString();

        timerSecondes += Time.deltaTime;
    }

    public GameObject GetPlayer() => player;
}
