using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DamageInfo
{
    public Attackable target;
    public int count;
    public int maxCount;
    public int damage;

    public string ToString()
    {
        return "target: " + target.name + "'\n count: " + count + " maxCount: " + maxCount + " damage: " + damage;
    }
}

public class Attackable : MonoBehaviour
{
    public virtual void Hitted(DamageInfo damageInfo) { }
}
