using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarSlider : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Slider slider;
    public Image fillImage;

    void Start()
    {
        if (playerHealth != null)
        {
            slider.maxValue = playerHealth.MaxHealth;
            slider.value = playerHealth.CurrentHealth;
        }
    }

    void Update()
    {
        if (playerHealth == null || slider == null || fillImage == null) return;

        float health = playerHealth.CurrentHealth;
        float max = playerHealth.MaxHealth;
        float percent = health / max;

        slider.value = health;

        fillImage.color = Color.Lerp(Color.red, Color.green, percent);

        transform.rotation = Quaternion.identity;
    }
}

