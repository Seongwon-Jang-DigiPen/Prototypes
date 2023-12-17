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

}
