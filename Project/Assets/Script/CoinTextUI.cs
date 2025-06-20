using UnityEngine;
using UnityEngine.UI;

public class CoinTextUI : MonoBehaviour
{
    public Text coinText;

    void Update()
    {
        coinText.text = CoinManager.Instance.GetSessionCoins().ToString();
    }
}

