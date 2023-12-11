using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
public class Wave : MonoBehaviour
{
    Disc _waveDisc;

    public float StartScale = 1;
    public float EndScae = 10;
    public float StartThickness = 5;
    public float EndThickness = 1;
    public AnimationCurve curve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));
    public float PlayTime = 136f / 60f;
    float timer = 0;
    void Start()
    {
        _waveDisc = GetComponent<Disc>();    
    }

    void Update()
    {
        float t = curve.Evaluate(timer / PlayTime);
        transform.localScale = Vector3.Lerp(Vector3.one * StartScale, Vector3.one * EndScae, t);
        _waveDisc.Thickness = Mathf.Lerp(StartThickness, EndThickness, t);

        if (timer < 1f)
        {
            timer += Time.deltaTime;
        }
    }
    public void Reset()
    {
        timer = 0;
    }
}
