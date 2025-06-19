using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject defeatPanel;

    public Button victoryRestartButton;
    public Button victoryQuitButton;

    public Button defeatRestartButton;
    public Button defeatQuitButton;

    void Start()
    {
        victoryPanel.SetActive(false);
        defeatPanel.SetActive(false);

        victoryRestartButton.onClick.AddListener(RestartLevel);
        victoryQuitButton.onClick.AddListener(QuitGame);

        defeatRestartButton.onClick.AddListener(RestartLevel);
        defeatQuitButton.onClick.AddListener(QuitGame);
    }

    public void ShowVictory()
    {
        Time.timeScale = 0f;
        victoryPanel.SetActive(true);
    }

    public void ShowDefeat()
    {
        Time.timeScale = 0f;
        defeatPanel.SetActive(true);
    }

    void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}

