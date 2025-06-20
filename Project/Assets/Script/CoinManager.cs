using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int totalCoins;
    private int sessionCoins;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadCoins();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin(int amount)
    {
        sessionCoins += amount;
    }

    public void SaveCoins()
    {
        totalCoins += sessionCoins;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();
    }

    public void LoadCoins()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        sessionCoins = 0;
    }

    public int GetSessionCoins()
    {
        return sessionCoins;
    }

    public void ResetSession()
    {
        sessionCoins = 0;
    }

#if UNITY_EDITOR
    public void ResetTotalCoins()
    {
        totalCoins = 0;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();
        Debug.Log("Monedas totales reiniciadas manualmente.");
    }
#endif

}


