using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TouchJoystick : MonoBehaviour
{
    public GameObject joystickUI;
    public RectTransform joystickBackground;
    public RectTransform joystickHandle;

    private Vector2 inputDirection = Vector2.zero;
    public Vector2 InputDirection => inputDirection;

    private Canvas canvas;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        joystickUI.SetActive(false);
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
                ShowJoystick(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            UpdateJoystick(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            HideJoystick();
        }
#else
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                ShowJoystick(touch.position);
        }
        else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
        {
            UpdateJoystick(touch.position);
        }
        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            HideJoystick();
        }
    }
#endif
    }


    void ShowJoystick(Vector2 screenPosition)
    {
        // Evita que aparezca en la parte superior de la pantalla (por ejemplo, el 25% superior)
        float screenHeight = Screen.height;
        float screenTopLimit = screenHeight * 0.75f; // 75% de altura joystick solo en parte inferior

        if (screenPosition.y > screenTopLimit)
            return; // No mostrar joystick si se toca en la zona restringida

        inputDirection = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;

        joystickUI.SetActive(true);

        Vector2 anchoredPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            screenPosition,
            canvas.worldCamera,
            out anchoredPos
        );

        joystickBackground.anchoredPosition = anchoredPos;
    }


    void UpdateJoystick(Vector2 screenPosition)
    {
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBackground,
            screenPosition,
            canvas.worldCamera,
            out localPos
        );

        localPos.x /= joystickBackground.sizeDelta.x;
        localPos.y /= joystickBackground.sizeDelta.y;

        inputDirection = new Vector2(localPos.x * 2, localPos.y * 2);
        inputDirection = inputDirection.magnitude > 1 ? inputDirection.normalized : inputDirection;

        joystickHandle.anchoredPosition = new Vector2(
            inputDirection.x * (joystickBackground.sizeDelta.x / 2),
            inputDirection.y * (joystickBackground.sizeDelta.y / 2));
    }

    void HideJoystick()
    {
        joystickUI.SetActive(false);
        inputDirection = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
    }
}
















