using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void OpenLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void OpenShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

