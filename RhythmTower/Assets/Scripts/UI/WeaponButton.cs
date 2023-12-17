using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class WeaponButton : MonoBehaviour, IPointerDownHandler
{
    public WeaponBase weapon;

    public void OnPointerDown(PointerEventData eventData)
    {
        double inputTime = NoteManager.Instance.BGMTime;
        if (weapon.fireAble() == false) { return; }
        if (NoteManager.Instance.TryHit(inputTime) == false) { return; }
        weapon.Fire();
    }
}
