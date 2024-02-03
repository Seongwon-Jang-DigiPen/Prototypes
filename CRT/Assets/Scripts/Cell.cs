using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;


public enum CellPos { Left = 0, Right, Up, Down, Count };

public class Cell : MonoBehaviour
{
    GameObject onwer;

    private readonly Vector2[] dir = new Vector2[4]
    {
        new Vector2(-1,0),new Vector2(1,0),new Vector2(0,-1),new Vector2(0,1)
    }; 
    public Cell[] NearCell = new Cell[4];
    public float Hp = 100;
    public float MaxHp = 100;
    void hitted(int count, int maxCount, int damage, HashSet<Cell> passedList)
    {
        if (passedList.Add(this))
        {
            Hp -= damage;
            for (int i = 0; i < NearCell.Length; ++i)
            {
                NearCell[i]?.hitted(count + 1, maxCount, damage / count + 1, passedList);
            }
            GetComponent<ShapeRenderer>().Color = Color.cyan * (Hp / MaxHp);
        }
    }

    void set()
    {
        for (int i = 0; i < (int)CellPos.Count; ++i)
        {
            Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y) + dir[i]);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        for (int i = 0; i < (int)CellPos.Count; ++i)
        {
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) + dir[i]);
        }
    }
}
