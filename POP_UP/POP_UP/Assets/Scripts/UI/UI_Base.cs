using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Base : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private bool _isPressed = false;
    public bool IsPressed { get { return _isPressed; } }
    private bool _wasPressed = false;
    public bool WasPressed { get { return _wasPressed; } }
    public bool isClicked => _wasPressed == false && _isPressed == true;

    virtual public void Update()
    {
        _wasPressed = _isPressed;
    }
    virtual public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
    }
    virtual public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
    }
}
