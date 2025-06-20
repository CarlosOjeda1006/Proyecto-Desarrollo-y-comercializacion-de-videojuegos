using UnityEngine;

public class BorrarMonedas : MonoBehaviour
{
    void Start()
    {
#if UNITY_EDITOR
        CoinManager.Instance.ResetTotalCoins();
#endif
    }

}
