using UnityEngine;
using UnityEngine.UI;

public class ShopCoinDisplay : MonoBehaviour
{
    public Text coinText;

    void Start()
    {
        if (coinText != null)
        {
            coinText.text = "Monedas: " + CoinManager.Instance.totalCoins.ToString();
        }
    }

    void Update()
    {
        coinText.text = "Monedas: " + CoinManager.Instance.totalCoins.ToString();
    }
}

