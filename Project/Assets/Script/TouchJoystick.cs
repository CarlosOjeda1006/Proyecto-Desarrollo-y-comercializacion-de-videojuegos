using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Image joystickBackground;
    public Image joystickHandle;

    private Vector2 inputDirection = Vector2.zero;
    public Vector2 InputDirection => inputDirection;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBackground.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out pos);

        pos.x /= joystickBackground.rectTransform.sizeDelta.x;
        pos.y /= joystickBackground.rectTransform.sizeDelta.y;

        inputDirection = new Vector2(pos.x * 2, pos.y * 2);
        inputDirection = (inputDirection.magnitude > 1) ? inputDirection.normalized : inputDirection;

        joystickHandle.rectTransform.anchoredPosition = new Vector2(
            inputDirection.x * (joystickBackground.rectTransform.sizeDelta.x / 2),
            inputDirection.y * (joystickBackground.rectTransform.sizeDelta.y / 2));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputDirection = Vector2.zero;
        joystickHandle.rectTransform.anchoredPosition = Vector2.zero;
    }
}












