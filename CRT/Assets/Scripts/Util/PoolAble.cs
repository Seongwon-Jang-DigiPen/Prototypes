using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PoolAble : MonoBehaviour
{
    public IObjectPool<PoolAble> Pool { get; set; }

    /*
     * init must call after generate object
     */
    public virtual void Init()
    {

    }

    public void ReleaseObject()
    {
        Pool.Release(this);
    }

    /*
     * Reset will call automatically
     */
    public virtual void Reset()
    {
        Debug.LogError("Poolable Obj must override Reset function");
    }
}