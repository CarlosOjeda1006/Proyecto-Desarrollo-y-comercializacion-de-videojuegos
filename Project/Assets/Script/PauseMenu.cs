using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuUI;
    public Button resumeButton;
    public Button resetButton;
    public Button quitButton;

    private bool isPaused = false;

    void Start()
    {
        menuUI.SetActive(false);

        resumeButton.onClick.AddListener(Resume);
        resetButton.onClick.AddListener(ResetLevel);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResetLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}

