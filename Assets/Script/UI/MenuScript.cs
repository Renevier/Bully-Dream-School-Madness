using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject menuParent;
    [SerializeField] GameObject skillTreeParent;

    public void GoToSkillTree()
    {
        menuParent.SetActive(false);
        skillTreeParent.SetActive(true);
    }

    public void ReturnToMenu()
    {
        menuParent.SetActive(true);
        skillTreeParent.SetActive(false);
    }

    public void LaunchGame() => SceneManager.LoadScene("CreationScene");
}
