using UnityEngine;
using UnityEngine.UI;

public class TutorialInstructions : MonoBehaviour
{
    public GameObject panel;
    public Button invisibleButton;

    void Start()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
        invisibleButton.onClick.AddListener(HideInstructions);
    }

    void HideInstructions()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}