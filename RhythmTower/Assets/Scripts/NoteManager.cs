using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 1. have all Note
/// 2. Caculate Note Time By BGM
/// 3. have info about where note go
/// </summary>
public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance { get { return _instance; } }
    private static NoteManager _instance;

    public List<Note> NoteList = new List<Note>();
    private AudioSource _bgmAS;
    public Action FuncPerBeat;
    public GameObject NoteUIPrefab;
    public GameObject NoteLineLeft;
    public GameObject NoteLineCenter;
    public GameObject NoteLineRight;
    public GameObject playUI;
    public double BGMTime => _bgmAS.time;
    public double BGMLength => _bgmAS.clip.length;

    public int BPM = 136;
    private double _timePerBeat => 60.0 / BPM;
    float funcCount = 0;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        _bgmAS = GetComponent<AudioSource>();
        makeNoteList();
    }

    private void Update()
    {
        double bgmTime = _bgmAS.time;
        if(bgmTime > funcCount * _timePerBeat + _timePerBeat)
        {
            funcCount++;
            FuncPerBeat();
        }
       
    }

    private void makeNoteList()
    {
        for (double i = _timePerBeat; i < _bgmAS.clip.length; i += _timePerBeat)
        {
            Note sn = new Note(i);
            NoteList.Add(sn);
            GameObject obj = Instantiate(NoteUIPrefab, playUI.transform);
            obj.GetComponent<NoteUI>().note = sn;
            obj.GetComponent<NoteUI>().noteManager = this;
            if( i > 20) { return; } // temp code
        }
    }
}
