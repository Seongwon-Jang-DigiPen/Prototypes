using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cell : MonoBehaviour
{
    GameObject onwer;
    Cell[] NearCell = new Cell[4];
    int Hp = 0;

    void hitted(int count, int maxCount, int damage, HashSet<Cell> passedList)
    {
        if (passedList.Add(this))
        {
            for (int i = 0; i < NearCell.Length; ++i)
            {
                NearCell[i]?.hitted(count + 1, maxCount, damage / count + 1, passedList);
            }
        }
    }
    
}
