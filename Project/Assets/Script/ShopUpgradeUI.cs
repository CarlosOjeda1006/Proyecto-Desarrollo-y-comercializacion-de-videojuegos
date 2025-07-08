using UnityEngine;
using UnityEngine.UI;

public class ShopUpgradeUI : MonoBehaviour
{
    public Button vidaButton;
    public Button velocidadButton;
    public Button dañoButton;
    public Text feedbackText;

    public int costoVida = 10;
    public int costoVelocidad = 10;
    public int costoDaño = 10;

    void Start()
    {
        vidaButton.onClick.AddListener(ComprarVida);
        velocidadButton.onClick.AddListener(ComprarVelocidad);
        dañoButton.onClick.AddListener(ComprarDaño);
    }

    public void ComprarVida()
    {
        Debug.Log("Monedas actuales: " + CoinManager.Instance.totalCoins);

        if (!PlayerUpgrades.Instance.PuedeMejorarVida())
        {
            feedbackText.text = "🛑 Vida al máximo.";
            return;
        }

        if (CoinManager.Instance.totalCoins >= costoVida)
        {
            CoinManager.Instance.totalCoins -= costoVida;
            PlayerUpgrades.Instance.vidaExtra += 1;
            PlayerUpgrades.Instance.GuardarMejoras();
            PlayerPrefs.SetInt("TotalCoins", CoinManager.Instance.totalCoins);
            feedbackText.text = "Vida Aumentada";
        }
        else
        {
            feedbackText.text = "¡No tienes suficientes monedas!";
        }
    }

    public void ComprarVelocidad()
    {
        if (!PlayerUpgrades.Instance.PuedeMejorarVelocidad())
        {
            feedbackText.text = "🛑 Velocidad al máximo.";
            return;
        }

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
        if (!PlayerUpgrades.Instance.PuedeMejorarDaño())
        {
            feedbackText.text = "🛑 Daño al máximo.";
            return;
        }

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



