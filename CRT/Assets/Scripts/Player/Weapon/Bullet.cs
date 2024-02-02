using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 Direction = Vector2.zero;
    public float bulletSpeed = 100;
    void Update()
    {
        transform.Translate(Direction * bulletSpeed * Time.deltaTime, Space.World);    
    }

    public void SetDirection(Vector2 dir)
    {
        Direction = dir;
    }
}
