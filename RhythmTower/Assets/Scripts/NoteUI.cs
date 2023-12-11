using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteUI : MonoBehaviour
{
    public NoteManager noteManager;
    public Note note;

    void Update()
    {
        this.transform.position = Vector3.Lerp(noteManager.NoteLineLeft.transform.position, noteManager.NoteLineCenter.transform.position, (float)(noteManager.BGMTime - note.MatchTime));
        if((float)(noteManager.BGMTime - note.MatchTime) * 1f >= 1f) { Destroy(this.gameObject); }
    }
}
