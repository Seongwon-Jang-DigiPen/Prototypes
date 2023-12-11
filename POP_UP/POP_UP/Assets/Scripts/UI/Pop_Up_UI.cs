using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using TMPro;
using UnityEngine.EventSystems;
public class Pop_Up_UI : MonoBehaviour,IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    

    Rectangle rectangle;
    BoxCollider2D boxCollider;
    TextMeshPro text;
    SpriteRenderer profileRenderer;
    bool _isPressed = false;
    Vector3 lastScreenPosition; 

    private void Awake()
    {
        rectangle = GetComponent<Rectangle>();
        boxCollider = GetComponent<BoxCollider2D>();
        text = GetComponentInChildren<TextMeshPro>();
        profileRenderer = GetComponentInChildren<SpriteRenderer>();


        boxCollider.size = new Vector2(rectangle.Width, rectangle.Height);
        Debug.Log($"{rectangle != null} {text != null} {profileRenderer != null}");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        _isPressed = true;
        lastScreenPosition = eventData.position;
    }

    void IPointerMoveHandler.OnPointerMove(PointerEventData eventData)
    {
        //if (_isPressed)
        //{
        //    Debug.Log("Move");

        //    Vector3 currWorldPos = Camera.main.ScreenToWorldPoint(eventData.position);
        //    Vector3 lastWorldPos = Camera.main.ScreenToWorldPoint(lastScreenPosition);
        //    transform.Translate(0, currWorldPos.y - lastWorldPos.y, 0);
        //    lastScreenPosition = eventData.position;
        //}
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up");
        _isPressed = false;
    }
}
