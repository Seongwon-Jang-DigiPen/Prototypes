using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHit : MonoBehaviour
{
    AudioSource AS;
    [SerializeField] AudioClip AC;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }
    private void Update()
    {
        double noteTime = NoteManager.Instance.BGMTime;
        if (NoteManager.Instance.LatestNote.MatchTime < NoteManager.Instance.BGMTime)
        {
            NoteManager.Instance.TryHit(noteTime);
            AS.PlayOneShot(AC);
        }
    }
}
