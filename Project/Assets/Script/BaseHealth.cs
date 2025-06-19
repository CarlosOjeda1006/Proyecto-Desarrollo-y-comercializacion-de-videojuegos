using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public float damageToProgress = 2f;

    public void TakeDamage(int damage)
    {
        float totalDamage = damage * damageToProgress;
        ProgressManager.Instance.ReduceProgress(totalDamage);

        Debug.Log("La base fue golpeada. Progreso reducido en: " + totalDamage);
    }
}


