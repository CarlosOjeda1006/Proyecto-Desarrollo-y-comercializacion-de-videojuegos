using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarSlider : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Slider slider;
    public Image fillImage;

    void Start()
    {
        if (playerHealth != null && slider != null)
        {
            slider.maxValue = playerHealth.MaxHealth;
            slider.value = playerHealth.CurrentHealth;
        }
    }

    void Update()
    {
        if (playerHealth == null || slider == null || fillImage == null)
            return;

        int current = playerHealth.CurrentHealth;
        int max = playerHealth.MaxHealth;

        slider.maxValue = max;
        slider.value = current;

        float percent = (float)current / max;

        if (percent > 0.5f)
        {
            fillImage.color = Color.Lerp(Color.yellow, Color.green, (percent - 0.5f) * 2);
        }
        else
        {
            fillImage.color = Color.Lerp(Color.red, Color.yellow, percent * 2);
        }

        transform.rotation = Quaternion.identity;
    }
}


