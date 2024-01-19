using UnityEngine;
using UnityEngine.Pool;

    public class OwnPool : MonoBehaviour
    {
        ObjectInfo objInfo;
        IObjectPool<PoolAble> unityPool;

        //초기화
        public void init(ObjectInfo info)
        {
            objInfo = info;
            unityPool = new ObjectPool<PoolAble>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
                OnDestroyPoolObject, true, objInfo.Count, objInfo.Count);
        }

        // 생성 callback
        private PoolAble CreatePooledItem()
        {
            GameObject poolGo = MonoBehaviour.Instantiate(objInfo.Prefab);

        PoolAble poolAble = poolGo.GetComponent<PoolAble>();
            poolAble.Pool = unityPool;
            poolGo.transform.SetParent(this.transform);
            return poolAble;
        }

        // 대여 callback
        private void OnTakeFromPool(PoolAble poolGo)
        { 
            poolGo.gameObject.SetActive(true);
        }

        // 반환 callback
        private void OnReturnedToPool(PoolAble poolGo)
        {
            poolGo.Reset();
            poolGo.gameObject.SetActive(false);
        }

        // 삭제 callback
        private void OnDestroyPoolObject(PoolAble poolGo)
        {
            MonoBehaviour.Destroy(poolGo);
        }

        public PoolAble Get()
        {
            return unityPool.Get();
        }
    }
