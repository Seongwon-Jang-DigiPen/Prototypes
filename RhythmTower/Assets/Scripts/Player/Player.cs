using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get { return _instance; } }
    private static Player _instance;

    public float Hp { get { return _hp; } }
    private float _hp;

    public float Mp { get { return _mp; } }
    private float _mp;

    public float Speed { get { return _speed; } set { _speed = value; } }
    private float _speed = 300;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            return;
        }
        Destroy(this.gameObject);
    }

    public void hitted(float damage)
    {
        _hp -= damage;
    }

    private void Update()
    {
        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
           dir += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector3.right;
        }
        transform.Translate(dir * Speed * Time.deltaTime);
    }
}
