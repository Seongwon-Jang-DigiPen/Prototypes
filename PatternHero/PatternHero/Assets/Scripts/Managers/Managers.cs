using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{

    static private Managers _instance;
    static public Managers Instance { get { return _instance; } }


    void Start()
    {
        if(_instance == null)
        {
            _instance = this;
            InitManagers();
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void InitManagers()
    {

    }
    
}
