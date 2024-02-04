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
        new Vector2(-1,0),new Vector2(1,0),new Vector2(0,1),new Vector2(0,-1)
    }; 
    public Cell[] NearCell = new Cell[4];
    public ShapeRenderer shape;
    public float Hp = 100;
    public float MaxHp = 100;
    private void Start()
    {
        shape = GetComponent<ShapeRenderer>();
        FindNearCell();
        shape.Color = Color.black * (Hp / MaxHp);
    }

    public void hitted(int count, int maxCount, int damage, HashSet<Cell> passedList)
    {
        if (passedList.Add(this))
        {
            Hp -= damage;
            for (int i = 0; i < NearCell.Length; ++i)
            {
                NearCell[i]?.hitted(count + 1, maxCount, damage / (count + 1), passedList);
            }
            shape.Color =   Color.black * (Hp / MaxHp) + Color.cyan *  (1 - (Hp / MaxHp));
        }
    }

    void FindNearCell()
    {
        for (int i = 0; i < (int)CellPos.Count; ++i)
        {
            RaycastHit2D[] hit2DArray = Physics2D.LinecastAll(transform.position, new Vector2(transform.position.x, transform.position.y) + dir[i]);
            foreach(RaycastHit2D hit2D in hit2DArray)
            {
                GameObject obj = hit2D.collider?.gameObject;
                Cell cell = obj?.GetComponent<Cell>();
                NearCell[i] = (cell != this && cell != null) ? cell : NearCell[i];
            } 
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
