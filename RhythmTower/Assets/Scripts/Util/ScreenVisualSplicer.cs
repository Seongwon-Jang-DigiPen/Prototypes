using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenVisualSplicer : MonoBehaviour
{
    public bool DrawHorizontalLine = true;
    public bool DrawVerticalLine = true;

    private void OnDrawGizmos()
    {
        Camera camera = Camera.main;
        int width = camera.scaledPixelWidth;
        int height = camera.scaledPixelHeight;

        //Vertical Line
        if (DrawVerticalLine)
        {
            Gizmos.DrawLine(camera.transform.position + Vector3.left * width / 6 + Vector3.up * 10000, camera.transform.position + Vector3.left * width / 6 + Vector3.down * 10000);
            Gizmos.DrawLine(camera.transform.position + Vector3.right * width / 6 + Vector3.up * 10000, camera.transform.position + Vector3.right * width / 6 + Vector3.down * 10000);
        }
        //horizontal Line
        if (DrawHorizontalLine)
        {
            Gizmos.DrawLine(camera.transform.position + Vector3.up * height / 6 + Vector3.left * 10000, camera.transform.position + Vector3.up * height / 6 + Vector3.right * 10000);
            Gizmos.DrawLine(camera.transform.position + Vector3.down * height / 6 + Vector3.left * 10000, camera.transform.position + Vector3.down * height / 6 + Vector3.right * 10000);
        }
    }
}
