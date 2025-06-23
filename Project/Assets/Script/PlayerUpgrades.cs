using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    public static PlayerUpgrades Instance;

    public int vidaExtra = 0;
    public float velocidadExtra = 0f;
    public float dañoExtra = 0f;

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
        dañoExtra = PlayerPrefs.GetFloat("DañoExtra", 0f);
    }

    public void GuardarMejoras()
    {
        PlayerPrefs.SetInt("VidaExtra", vidaExtra);
        PlayerPrefs.SetFloat("VelocidadExtra", velocidadExtra);
        PlayerPrefs.SetFloat("DañoExtra", dañoExtra);
        PlayerPrefs.Save();
    }
}

