 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    //Have a All Instance in Play Scene

    public PlayManager Instance { get { return _instance; } }
    private PlayManager _instance = null;

    public static Player Player => Player.Instance;
    public static NoteManager NoteManager =>  NoteManager.Instance;

    void Start()
    {
        if(_instance == null)
        {
            _instance = this;
            return;
        }
        Destroy(gameObject);
    }

    void Update()
    {
       
    }
}


