using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[Serializable]
public class Note
{
    public enum NoteState
    {
        Normal, Hitted, Failed, Passed
    }
    /*end to move*/
    public bool IsEnd { get
        {
            double time = NoteManager.Instance.BGMTime;
            return MatchTime < time && GetAccuracyPercentage(time) <= 0;
        }
    }

    public NoteState State = NoteState.Normal;

    public Note(double matchTime)
    {
        _matchTime = matchTime;
    }
    public double MatchTime { get { return _matchTime; } set { _matchTime = value; } }
    [SerializeField]
    private double _matchTime;

    //public double Accuracy => noteManager.BGMTime - note.MatchTime
    public double GetAccuracy(double CurrBGMTime)
    {
        return 1.0 - Math.Abs(MatchTime - CurrBGMTime);
    }
    public double GetAccuracyPercentage(double CurrBGMTime)
    {
        return 100.0 * GetAccuracy(CurrBGMTime);
    }
}