using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
    public struct ObjectInfo
    {
        public ObjectInfo(string objName, GameObject prefab, int count)
        {
            ObjectName = objName;
            Prefab = prefab;
            Count = count;
        }

        // 오브젝트 이름
        public string ObjectName;
        // 오브젝트 풀에서 관리할 오브젝트
        public GameObject Prefab;
        // 최대 숫자
        public int Count;
    }
  
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager Instance { get { return _instance; } }
        private static ObjectPoolManager _instance = null;
        private Dictionary<string, OwnPool> objectpoolList = new Dictionary<string, OwnPool>();

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
        }

        // 생성

        public GameObject generate(string goName)
        {
            if (objectpoolList.ContainsKey(goName) == false)
            {
                Debug.LogFormat($"{goName} 오브젝트풀에 등록되지 않은 오브젝트입니다.");
                return null;
            }

            return objectpoolList[goName].Get().gameObject;
        }


        public GameObject generate(ObjectInfo info)
        {
            if (objectpoolList.ContainsKey(info.ObjectName) == false)
            {
                GenerateObjectPool(info);
            }

            return objectpoolList[info.ObjectName].Get().gameObject;
        }

        public GameObject generate<T>()
        {
            return generate(typeof(T).Name);
        }

        public void GenerateObjectPool(ObjectInfo info)
        {
            if (objectpoolList.ContainsKey(info.ObjectName) == true)
            {
                Debug.LogError($"{info.ObjectName} already have own pool");
            }
            GameObject obj = new GameObject(info.ObjectName);
            obj.transform.SetParent(this.transform);

            OwnPool pool = obj.AddComponent<OwnPool>();
            objectpoolList.Add(info.ObjectName, pool);

            pool.init(info);
        }

        public void GenerateObjectPool<T>(GameObject prefab, int count = 10) where T : MonoBehaviour
        {
            string name = typeof(T).Name;
            ObjectInfo info = new ObjectInfo(name, prefab, count);
            GenerateObjectPool(info);
        }

        public void GenerateObjectPool(string name, GameObject prefab, int count)
        {
            ObjectInfo info = new ObjectInfo(name, prefab, count);
            GenerateObjectPool(info);
        }
    }
