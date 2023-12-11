using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI.Extensions;
public class LineController : MonoBehaviour
{
    static public LineController test;

    UILineRenderer _lineRenderer;
    private void Awake()
    {
        _lineRenderer = GetComponent<UILineRenderer>();
        test = this;
    }

    public void StartPoint(Vector2 point)
    {
        
            //transform.position = point;
         
    }
    public void AddPoint(Vector2 point)
    {
        var pointList = new List<Vector2>(_lineRenderer.Points);

        pointList.Add(point);
        _lineRenderer.Points = pointList.ToArray();
    }
    public void ResetLine()
    {
        _lineRenderer.Points = (new List<Vector2>()).ToArray();
    }
}
