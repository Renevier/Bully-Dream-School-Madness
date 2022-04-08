using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform pause;
    [SerializeField] PlayerController player;
    [SerializeField] Image healthImg;
    [SerializeField] Image energyImg;
    [SerializeField] TextMeshProUGUI timerTxt;
    [SerializeField] TextMeshProUGUI coinTxt;

    private float timerSecondes = 0;
    private int nbCoins = 0;

    private void Update()
    {
        if(Time.timeScale == 0)
            pause.gameObject.SetActive(true);
        else
            pause.gameObject.SetActive(false);

        coinTxt.text = nbCoins.ToString();
        healthImg.fillAmount = player.GetCurrentLife() / player.GetPlayerData().GetMaxHealth();
        energyImg.fillAmount = player.GetCurrentEnergy() / player.GetPlayerData().GetMaxEnergy();

        Timer();
    }

    private void Timer()
    {
        timerTxt.text = ((int)timerSecondes).ToString();

        timerSecondes += Time.deltaTime;
    }

    public void AddCoin(int _nbCoin) => nbCoins += _nbCoin;
    public PlayerController GetPlayer() => player;
    public float GetTime() => timerSecondes;
}
