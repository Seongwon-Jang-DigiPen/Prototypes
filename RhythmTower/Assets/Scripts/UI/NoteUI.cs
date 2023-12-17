using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class NoteUI : PoolAble
{
    public NoteUIManager noteUIManager;
    public Note note;

    void Update()
    {
        Rect box = Camera.main.pixelRect;
        Vector3 left = new Vector3(-box.xMax / 2, 0, 0);
        Vector3 right = new Vector3(box.xMax / 2, 0, 0);

        this.transform.position = Vector3.Lerp(left, right, (float)(1 + NoteManager.Instance.BGMTime - note.MatchTime) / 2f);

        tempRhythmChecker();

        if (note.IsEnd == true)
        {
            ReleaseObject();
        }
    }

    public override void Init()
    {
        transform.SetParent(noteUIManager.transform);

        Rect box = Camera.main.pixelRect;
        Vector3 left = new Vector3(-box.xMax / 2, 0, 0);
        Vector3 right = new Vector3(box.xMax / 2, 0, 0);

        this.transform.position = Vector3.Lerp(left, right, (float)(1 + NoteManager.Instance.BGMTime - note.MatchTime) / 2f);
    }

    public override void Reset()
    {
        note = null;
    }

    public void tempRhythmChecker()
    {
        
        switch (note.State)
        {
            case Note.NoteState.Normal:
                if (NoteManager.Instance.HitAccuracy < note.GetAccuracyPercentage(NoteManager.Instance.BGMTime))
                {
                    GetComponent<Shapes.Disc>().Color = Color.blue;
                }
                else
                {
                    GetComponent<Shapes.Disc>().Color = Color.black;
                }
                break;
            case Note.NoteState.Hitted:
                GetComponent<Shapes.Disc>().Color = Color.green;
                break;
            case Note.NoteState.Failed:
                GetComponent<Shapes.Disc>().Color = Color.red;
                break;
            case Note.NoteState.Passed:
                GetComponent<Shapes.Disc>().Color = Color.grey;
                break;
        }
        
    }
}
