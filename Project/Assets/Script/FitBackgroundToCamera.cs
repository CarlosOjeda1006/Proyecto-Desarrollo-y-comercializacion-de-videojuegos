using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FitBackgroundToCamera : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        float height = 2f * Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;

        Vector2 spriteSize = sr.sprite.bounds.size;
        transform.localScale = new Vector3(
            width / spriteSize.x,
            height / spriteSize.y,
            1f
        );
    }
}

