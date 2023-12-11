using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MessageSessionUI : UI_Base, IPointerMoveHandler
{
    bool _isDragged = false;
    Vector3 lastScreenPosition;
    float _minY = -8;
    float _maxY = 0;

    public override void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pushed");
        _isDragged = false;
        lastScreenPosition = eventData.position;
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        if(_isDragged == false)
        {
            Debug.Log("Go Inside");
        }
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        _isDragged = true;
        if (IsPressed)
        {
            Debug.Log("Moved");
            Vector3 currWorldPos = Camera.main.ScreenToWorldPoint(eventData.position);
            Vector3 lastWorldPos = Camera.main.ScreenToWorldPoint(lastScreenPosition);

            Vector3 pos = transform.parent.position;
            pos.y = Mathf.Max(_minY, Mathf.Min(_maxY, pos.y + currWorldPos.y - lastWorldPos.y));
            transform.parent.position = pos;
            lastScreenPosition = eventData.position;
        }
    }
}
