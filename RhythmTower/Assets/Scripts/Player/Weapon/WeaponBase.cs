using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum WeaponList
{
    Bullet, Wave,
}

public class WeaponBase : MonoBehaviour
{
    WeaponManager _weaponManager;
    [SerializeField]
    private float _mpConsumption;
    public float Mpconsumption { get { return _mpConsumption; } }
    [SerializeField]
    private float _cooldown;
    public float Cooldown { get { return _cooldown; } }

    virtual public void BeatUpdate()
    {
        _cooldown = Mathf.Max(_cooldown - 1, 0);
    }

    public virtual void Fire()
    {
        Debug.Log("You Must Override Fire function");
    }

    public bool fireAble()
    {
        return true;
        //return currMp >= _mpConsumption;
    }
}
