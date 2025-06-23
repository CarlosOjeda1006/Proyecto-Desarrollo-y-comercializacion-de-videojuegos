using UnityEngine;
using UnityEngine.UI;

public class ShopUpgradeUI : MonoBehaviour
{
    public Button vidaButton;
    public Button velocidadButton;
    public Button dañoButton;
    public Text feedbackText;

    public int costoVida = 1;
    public int costoVelocidad = 1;
    public int costoDaño = 1;

    void Start()
    {
        vidaButton.onClick.AddListener(ComprarVida);
        velocidadButton.onClick.AddListener(ComprarVelocidad);
        dañoButton.onClick.AddListener(ComprarDaño);
    }

    // 👇 Estas funciones ahora son públicas
    public void ComprarVida()
    {
        if (CoinManager.Instance.totalCoins >= costoVida)
        {
            CoinManager.Instance.totalCoins -= costoVida;
            PlayerUpgrades.Instance.vidaExtra += 1;
            PlayerUpgrades.Instance.GuardarMejoras();
            PlayerPrefs.SetInt("TotalCoins", CoinManager.Instance.totalCoins);
            feedbackText.text = "🩸 +1 Vida Extra Comprada!";
        }
        else
        {
            feedbackText.text = "¡No tienes suficientes monedas!";
        }
    }

    public void ComprarVelocidad()
    {
        if (CoinManager.Instance.totalCoins >= costoVelocidad)
        {
            CoinManager.Instance.totalCoins -= costoVelocidad;
            PlayerUpgrades.Instance.velocidadExtra += 0.5f;
            PlayerUpgrades.Instance.GuardarMejoras();
            PlayerPrefs.SetInt("TotalCoins", CoinManager.Instance.totalCoins);
            feedbackText.text = "💨 Velocidad aumentada!";
        }
        else
        {
            feedbackText.text = "¡No tienes suficientes monedas!";
        }
    }

    public void ComprarDaño()
    {
        if (CoinManager.Instance.totalCoins >= costoDaño)
        {
            CoinManager.Instance.totalCoins -= costoDaño;
            PlayerUpgrades.Instance.dañoExtra += 0.5f;
            PlayerUpgrades.Instance.GuardarMejoras();
            PlayerPrefs.SetInt("TotalCoins", CoinManager.Instance.totalCoins);
            feedbackText.text = "🔫 Disparo mejorado!";
        }
        else
        {
            feedbackText.text = "¡No tienes suficientes monedas!";
        }
    }
}

