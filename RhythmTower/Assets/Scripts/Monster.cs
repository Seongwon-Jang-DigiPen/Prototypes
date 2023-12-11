using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private float _maxHp = 100;
    public float Hp { get { return _hp; } set { _hp = value; } }
    [SerializeField]
    private float _hp;

    public float Speed = 100;

    readonly Color bodyColor = new Color32(255, 83, 83, 255);
    Shapes.Rectangle body;
    Cannon _cannon;
    private void Start()
    {
        _hp = _maxHp;
        body = GetComponent<Shapes.Rectangle>();
        _cannon = FindAnyObjectByType<Cannon>();
    }

    private void Update()
    {
        body.Color = bodyColor * (_maxHp/ _hp);
        move();
    }

    private void Dead()
    {
        Destroy(gameObject);
    }

    public void move()
    {
        Vector2 dir = new Vector2(_cannon.transform.position.x - transform.position.x, _cannon.transform.position.y - transform.position.y).normalized;
        transform.Translate(dir * Speed * Time.deltaTime);
    }
}
