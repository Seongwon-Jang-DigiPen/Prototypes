using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Slider : UI_Base, IPointerMoveHandler
{
    Vector2 startPos;
    Vector2 endPos;
    Vector3 lastScreenPosition;

    private void Awake()
    {
        startPos = transform.localPosition;
        endPos = new Vector2(3.5f, 0);
    }

    override public void Update()
    {
        if(IsPressed == false)
        {
            if(calculatePercent() > 0.8)
            {
                moveTo(endPos);
            }
            else
            {
                moveTo(startPos);
            }
        }
        
    }

    float calculatePercent()
    {
        Vector2 currPos = transform.position;
        return Mathf.Abs(currPos.x - startPos.x) / Mathf.Abs(endPos.x - startPos.x);
    }
    void moveTo(Vector2 pos)
    {
        transform.localPosition = pos;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (IsPressed)
        {
            Debug.Log("Moved");
            Vector3 currWorldPos = Camera.main.ScreenToWorldPoint(eventData.position);
            Vector3 lastWorldPos = Camera.main.ScreenToWorldPoint(lastScreenPosition);

            Vector3 lPos = transform.localPosition;
            lPos.x = Mathf.Max(startPos.x, Mathf.Min(endPos.x, lPos.x + currWorldPos.x - lastWorldPos.x));
            transform.localPosition = lPos;
            lastScreenPosition = eventData.position;
        }
    }

    override public void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        lastScreenPosition = eventData.position;
    }    
}
