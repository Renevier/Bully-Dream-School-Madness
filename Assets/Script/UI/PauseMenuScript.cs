using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public void Resume() => Time.timeScale = 1;
    public void GoMenu()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MenuScene");
    }
}
