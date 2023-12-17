using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class HitVisualizer : MonoBehaviour
{
    public float verticalLineLength = 100;
    public float thinkness = 10;
    private void OnDrawGizmos()
    {
        NoteManager noteMananger = FindAnyObjectByType<NoteManager>();
        Rect box = Camera.main.pixelRect;
        Vector3 left = new Vector3(-box.xMax / 2, 0, 0);
        Vector3 right = new Vector3(box.xMax / 2, 0, 0);
        Vector3 Center = Vector3.Lerp(left, right, 1f / 2f);

        float hitAccurcy = (float)noteMananger.HitAccuracy / 100f;
        Vector3 HitBox = Vector3.Lerp(left, right, (float)(1 - (1 - noteMananger.MinimumHitBoxAccurcy / 100)) / 2f);

        Vector3 HitStart = Vector3.Lerp(left, right,(1 - (1 - hitAccurcy)) / 2f);
        Vector3 HitEnd = Vector3.Lerp(left, right,  (1 + (1 - hitAccurcy)) / 2f);

        Gizmos.color = Color.yellow;
        drawVerticalLine(HitBox);

        Gizmos.color = Color.blue;
        drawVerticalLine(HitStart);
        drawVerticalLine(HitEnd);

        Gizmos.color = Color.green;
        drawVerticalLine(Center);

        void drawVerticalLine(Vector3 pos)
        {
            Gizmos.DrawCube(new Vector2(pos.x, 0), new Vector2(thinkness, verticalLineLength));
            //Gizmos.DrawLine(new Vector2(pos.x, -verticalLineLength/2), new Vector2(pos.x, verticalLineLength/2));
;        }
    }
}
