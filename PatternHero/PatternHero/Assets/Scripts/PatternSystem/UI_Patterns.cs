using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Pattern
{
    public class UI_Patterns : MonoBehaviour
    {
        //public GameObject PatternNodePreb;
        void Start()
        {
        }
        private void OnDrawGizmos()
        {
            if(Managers.Instance == null) { return; }
            List<PatternNode> list = TurnManager.Instance.player.AttackManager.LinkedNode;
            for (int i = 0; i < list.Count - 1; ++i) {
                Gizmos.DrawLine(list[i].transform.position, list[i + 1].transform.position);
               }
            if(list.Count != 0)
            {;
                Gizmos.DrawLine(list[list.Count - 1].transform.position, Input.mousePosition);
            }
        }
    }
}