using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public void Resume() => Time.timeScale = 1;
    public void GoMenu() => UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
}
