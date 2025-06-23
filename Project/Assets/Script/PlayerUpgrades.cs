using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    public static PlayerUpgrades Instance;

    public int vidaExtra = 0;
    public float velocidadExtra = 0f;
    public float da�oExtra = 0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CargarMejoras();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CargarMejoras()
    {
        vidaExtra = PlayerPrefs.GetInt("VidaExtra", 0);
        velocidadExtra = PlayerPrefs.GetFloat("VelocidadExtra", 0f);
        da�oExtra = PlayerPrefs.GetFloat("Da�oExtra", 0f);
    }

    public void GuardarMejoras()
    {
        PlayerPrefs.SetInt("VidaExtra", vidaExtra);
        PlayerPrefs.SetFloat("VelocidadExtra", velocidadExtra);
        PlayerPrefs.SetFloat("Da�oExtra", da�oExtra);
        PlayerPrefs.Save();
    }
}

