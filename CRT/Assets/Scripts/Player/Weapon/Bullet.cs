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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var cell = collision.gameObject.GetComponent<Cell>();
        if(cell)
        {
            Destroy(this.gameObject);
            cell.hitted(0, 2, 10, new HashSet<Cell>());
        }
    }
}
