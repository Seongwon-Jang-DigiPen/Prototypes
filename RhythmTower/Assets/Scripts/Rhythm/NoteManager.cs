using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEditor.Experimental.GraphView;
/// <summary>
/// Management all Note during play Scene
/// 1. Have all Note
/// 2. Update Note (passed, hitted, failed)
/// 3. Note Hit Check
/// </summary>
public class NoteManager : MonoBehaviour
{
    #region Properties
    /*Singleton*/
    public static NoteManager Instance { get { return _instance; } }
    private static NoteManager _instance;

    /*Sound*/
    private AudioSource _bgmAS; // temp Code
    public double BGMTime => _bgmAS.time;
    public double BGMLength => _bgmAS.clip.length;
    public int BPM = 136;
    private double _timePerBeat => 60.0 / BPM;

    /*Note*/
    public List<Note> NoteList { get { return _noteList; } }
    private List<Note> _noteList = new List<Note>();
    public int LatestIndex { get { return _latestIndex; } }
    private int _latestIndex = 0;
    public Note LatestNote => _noteList[_latestIndex];

    /*HitCheck*/
    public double HitAccuracy = 80;
    public double MinimumHitBoxAccurcy = 60;
    #endregion

    #region UnityFunction
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
        _bgmAS = GetComponent<AudioSource>(); // temp code
        MakeNoteList(); // temp code
    }

    private void Update()
    {
        NoteEndCheck();
    }
    #endregion

    #region HitCheck

    public bool TryHit(double inputTime)
    {
        if (_noteList.Count <= _latestIndex || IsLatestNoteInsideHitbox(inputTime) == false) // note is end || pressed button before note come
        {
            return false;
        }
        if (CanHit(inputTime) == true)
        {
            HitNote(); // pressed button right timing
            return true;
        }
        FailNote(); // pressed button wrong timing
        return false;
    }

    private void HitNote()
    {
        LatestNote.State = Note.NoteState.Hitted;
        ChangeLatestNote();
    }

    private void FailNote()
    {
        LatestNote.State = Note.NoteState.Failed;
        ChangeLatestNote();
    }

    private bool CanHit(double inputTime)
    {
        return HitAccuracy <= LatestNote.GetAccuracyPercentage(inputTime);
    }

    private bool IsLatestNoteInsideHitbox(double inputTime)
    {
        if (LatestNote.GetAccuracyPercentage(inputTime) > MinimumHitBoxAccurcy)
        {
            return true;
        }
        return false;
    }

    #endregion

    #region UpdateNote
    private void NoteEndCheck()
    {
        if (_noteList.Count > _latestIndex) 
        {
            if (_noteList[_latestIndex].MatchTime < _bgmAS.time && HitAccuracy > _noteList[_latestIndex].GetAccuracyPercentage(_bgmAS.time)) // tempCode
            {
                LatestNote.State = Note.NoteState.Passed;
                ChangeLatestNote();
            }
        }
    }

    public void ChangeLatestNote()
    {
        _latestIndex++;
    }
    #endregion

    #region GenereateNote
    private void MakeNoteList() //temp code
    {
        for (double i = 0.068; i < _bgmAS.clip.length; i += _timePerBeat)
        {
            Note sn = new Note(i);
            _noteList.Add(sn);
        }
    }

    #endregion
}




