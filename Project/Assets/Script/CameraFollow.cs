using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float fixedX = 0f;
    public Vector3 offset = new Vector3(0f, 0f, -10f);

    public float minY = -6.25f;
    public float maxY = 6.25f;

    void LateUpdate()
    {
        if (target == null) return;

        float clampedY = Mathf.Clamp(target.position.y, minY, maxY);
        transform.position = new Vector3(fixedX, clampedY, offset.z);
    }
}





