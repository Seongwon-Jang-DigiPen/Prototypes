using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 Direction = Vector2.zero;
    public float damage = 50;
    public int spread = 3;
    public float bulletSpeed = 100;
    bool isHitted = false;
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
        if(cell && isHitted == false)
        {
            isHitted = true;
            Destroy(this.gameObject);
            DamageInfo info;

            info.target = cell;
            info.maxCount = spread;
            info.count = 0;
            info.damage = 50;
            cell.Hitted(info);

        }
    }
}
