using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using MoreMountains.Feedbacks;
public class WaveButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject wavePrefab;
    public GameObject PlayUI;
    public Transform generateTr;
    public void OnPointerDown(PointerEventData eventData)
    {
        GenerateWave();
    }
    void GenerateWave()
    {
        GameObject obj = Instantiate(wavePrefab, generateTr.position, wavePrefab.transform.rotation);
        obj.transform.parent = PlayUI.transform;
        Destroy(obj, 1);
    }
    
}
