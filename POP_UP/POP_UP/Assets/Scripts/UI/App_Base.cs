using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class App_Base : UI_Base, IPointerClickHandler
{
    static public bool IsStartApp = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(IsStartApp == true) { return; }
        IsStartApp = true;
        StartCoroutine(PlayApp());
    }

    virtual public IEnumerator PlayApp()
    {
        Debug.Log("App Started");
        yield return null;
        IsStartApp = false;
    }


    
}
