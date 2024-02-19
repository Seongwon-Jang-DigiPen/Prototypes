using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;


public enum CellPos { Left = 0, Right, Up, Down, Count };

public class Cell : Attackable
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

    public override void Hitted(DamageInfo damageInfo)
    {

        Queue<DamageInfo> q = new Queue<DamageInfo>();

        damageInfo.target = this;

        HashSet<Cell> s = new HashSet<Cell>();
        q.Enqueue(damageInfo);

        bfs();

        void bfs()
        {
            while (q.Count > 0)
            {
                DamageInfo iter = q.Dequeue();
                Cell cell = iter.target.GetComponent<Cell>();

                s.Add(cell);
                GetDamage(iter.damage / (iter.count + 1));

                if (iter.count + 1 >= iter.maxCount) { continue; }
                iter.count++;

                for (int i = 0; i < cell.NearCell.Length; ++i)
                {
                    if (cell.NearCell[i] != null)
                    {
                        if (s.Contains(cell.NearCell[i]) == true) { continue; }
                        DamageInfo temp = iter;
                        temp.target = cell.NearCell[i];
                        q.Enqueue(temp);
                    }
                }
            }
        }
    }   


    private void GetDamage(int damage)
    {
        Hp -= damage;
        shape.Color = Color.black * (Hp / MaxHp) + Color.cyan * (1 - (Hp / MaxHp));
    }

    //using raycast to find near cell
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
