using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
public class NoteUIManager : MonoBehaviour
{
    public GameObject NoteUIPrefab;
    private int _index = 0;
    public MMF_Player center_Player;
    float timer;
    private void Start()
    {
        ObjectPoolManager.Instance.GenerateObjectPool<NoteUI>(NoteUIPrefab, 10);  
    }

    private void Update()
    {
        if (NoteManager.Instance.BGMTime > timer)
        {
            timer += 60.0f / NoteManager.Instance.BPM;
            center_Player.PlayFeedbacks(); //temp code
        }
        if (_index < NoteManager.Instance.NoteList.Count && NoteManager.Instance.NoteList[_index].GetAccuracyPercentage(NoteManager.Instance.BGMTime) >= 0.0)
        {
            GenerateUI(NoteManager.Instance.NoteList[_index]);
            _index++;
        }
    }
   
    void GenerateUI(Note note)
    {
        GameObject obj = ObjectPoolManager.Instance.generate<NoteUI>();
        NoteUI noteUI = obj.GetComponent<NoteUI>();
        noteUI.note = note;
        noteUI.noteUIManager = this;
        noteUI.Init();
    }
}