using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject finalVictoryPanel;
    public GameObject defeatPanel;

    public Button victoryRestartButton;
    public Button victoryQuitButton;
    public Button victoryMenuButton;
    public Button victoryNextLevelButton;

    public Button finalVictoryRestartButton;
    public Button finalVictoryQuitButton;
    public Button finalVictoryMenuButton;

    public Button defeatRestartButton;
    public Button defeatQuitButton;

    public Text coinText;

    void Start()
    {
        victoryPanel.SetActive(false);
        finalVictoryPanel.SetActive(false);
        defeatPanel.SetActive(false);

        victoryRestartButton.onClick.AddListener(RestartLevel);
        victoryQuitButton.onClick.AddListener(QuitGame);
        victoryMenuButton.onClick.AddListener(BackToMainMenu);
        victoryNextLevelButton.onClick.AddListener(NextLevel);

        finalVictoryRestartButton.onClick.AddListener(RestartLevel);
        finalVictoryQuitButton.onClick.AddListener(QuitGame);
        finalVictoryMenuButton.onClick.AddListener(BackToMainMenu);

        defeatRestartButton.onClick.AddListener(RestartLevel);
        defeatQuitButton.onClick.AddListener(QuitGame);
    }

    public void ShowVictory()
    {
        Time.timeScale = 0f;

        if (coinText != null)
            coinText.text = "Monedas obtenidas: " + CoinManager.Instance.totalCoins;

        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        bool isLastLevel = currentIndex >= totalScenes - 2;

        if (isLastLevel)
        {
            finalVictoryPanel.SetActive(true);
        }
        else
        {
            victoryPanel.SetActive(true);
        }
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

    void NextLevel()
    {
        Time.timeScale = 1f;
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextIndex);
    }

    void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}


