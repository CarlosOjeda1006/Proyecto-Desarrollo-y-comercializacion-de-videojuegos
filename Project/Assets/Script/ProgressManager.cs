using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;

    public Slider progressBar;
    public float progress = 0f;
    public float maxProgress = 100f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        progressBar.maxValue = maxProgress;
        progressBar.value = progress;
    }

    public void AddProgress(float amount)
    {
        progress += amount;
        progress = Mathf.Clamp(progress, 0, maxProgress);
        progressBar.value = progress;

        if (progress >= maxProgress)
        {
            Debug.Log("¡Has ganado!");
            Object.FindFirstObjectByType<EndGameUI>().ShowVictory();
        }

    }

    public void ReduceProgress(float amount)
    {
        AddProgress(-amount);
    }
}

