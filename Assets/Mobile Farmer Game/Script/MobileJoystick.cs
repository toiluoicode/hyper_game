using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileJoystick : MonoBehaviour
{

    [Header("Element")]
    [SerializeField] private RectTransform joystickOutLine;
    [SerializeField] private RectTransform joystickKnob;


    [Header("Setting")]
    private bool canControl;
    private Vector3 clickedPosition;
    [SerializeField] private int moveFactor;
    private Vector3 move;
    void Start()
    {
        HideJoystick();
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl)
        {
            ControlJoysick();
        }
    }
    public void ClickOnJoystickCallback()
    {
        clickedPosition = Input.mousePosition;
        joystickOutLine.position = clickedPosition;
        ShowJoystick();

    }
    public void ShowJoystick()
    {
        joystickOutLine.gameObject.SetActive(true);
        canControl = true;
    }
    public void HideJoystick()
    {
        joystickOutLine.gameObject.SetActive(false);
        canControl = false;
        move = Vector3.zero;
    }
    public void ControlJoysick()
    {
        Vector3 currentPosition = Input.mousePosition;
        Vector3 direction = currentPosition - clickedPosition;
        float moveMagnitude = direction.magnitude * moveFactor / Screen.width;
        moveMagnitude = Mathf.Min(moveMagnitude, joystickOutLine.rect.width / 2);
        move = direction.normalized * moveMagnitude;
        Vector3 targetPosition = clickedPosition + move;
        joystickKnob.position = targetPosition;
        if (Input.GetMouseButtonUp(0))
        {
            HideJoystick();
        }
    }
    public Vector3 GetMoveVector()
    {
        return move;
    }
}
