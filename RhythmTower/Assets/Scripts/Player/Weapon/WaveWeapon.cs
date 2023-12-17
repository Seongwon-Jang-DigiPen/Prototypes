using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveWeapon : WeaponBase
{
    [SerializeField]
    GameObject wavePrefab;

    private void Start()
    {
        Managers.ObjPool.GenerateObjectPool<Wave>(wavePrefab, 100);
    }

    public override void Fire()
    {
        GameObject obj = Managers.ObjPool.generate<Wave>();
        obj.GetComponent<PoolAble>().Init();
        obj.transform.position = Player.Instance.transform.position;
    }
}
