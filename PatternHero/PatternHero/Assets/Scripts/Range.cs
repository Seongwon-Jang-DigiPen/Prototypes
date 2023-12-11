using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Range // 장기적인 문제점은 ㄱ ㄴ 과 같은 모양은 적용을 못함, 추후 interface 사용 예정 (혹은 Abstract)
{
    public Vector2Int Pos;
    public Vector2Int Size;
    public Vector2Int Max => new Vector2Int(Pos.x + Size.x, Pos.y + Size.y);
    public Vector2Int Min => Pos;

    public bool Overlap(Range target)
    {
        return Overlap(this, target);
    }

    static public bool Overlap(Range a, Range b)
    {

        if (a.Min.x >= b.Max.x || a.Max.x <= b.Min.x) return false;
        if (a.Min.y >= b.Max.y || a.Max.y <= b.Min.y) return false; //겹쳐있는 것 또한 미포함 할 것

        return true;
    }
}