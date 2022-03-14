using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI timerTxt;

    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;

        timerTxt.text = timer.ToString();
    }
    
    public GameObject GetPlayer() => player;
}
