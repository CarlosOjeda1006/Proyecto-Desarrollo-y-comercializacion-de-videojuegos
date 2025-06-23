using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;

    public Slider progressBar;
    public float progress = 0f;
    public float maxProgress = 100f;

    [Header("Jefes por nivel")]
    public GameObject jefeRatonPrefab;
    public GameObject jefeHongoPrefab;
    public Transform puntoAparicion;

    private bool jefeInvocado = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CoinManager.Instance.ResetSession();
        progressBar.maxValue = maxProgress;
        progressBar.value = progress;
    }

    public void AddProgress(float amount)
    {
        progress += amount;
        progress = Mathf.Clamp(progress, 0, maxProgress);
        progressBar.value = progress;

        if (progress >= maxProgress && !jefeInvocado)
        {
            jefeInvocado = true;
            InvocarJefeDelNivel();
        }
    }

    public void ReduceProgress(float amount)
    {
        AddProgress(-amount);
    }

    void InvocarJefeDelNivel()
    {
        string nombreNivel = SceneManager.GetActiveScene().name;

        if (nombreNivel == "Level2" && jefeRatonPrefab != null)
        {
            Instantiate(jefeRatonPrefab, puntoAparicion.position, Quaternion.identity);
        }
        else if (nombreNivel == "Level3" && jefeHongoPrefab != null)
        {
            Instantiate(jefeHongoPrefab, puntoAparicion.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No hay jefe asignado para este nivel. Terminando nivel.");
            Object.FindFirstObjectByType<EndGameUI>().ShowVictory();
        }
    }

    // Método para ser llamado cuando el jefe muere
    public void JefeDerrotado()
    {
        Object.FindFirstObjectByType<EndGameUI>().ShowVictory();
    }
}


