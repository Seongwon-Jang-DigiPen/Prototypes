using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavGraph
{
    public class Node
    {
        private Vector2 _pos;
        public Vector2 Pos { get { return _pos; } set { _pos = value; } }
        private List<Node> _linked;
        public List<Node> Linked { get { return _linked; } }
        private Node()
        {

        }
        public Node(Vector2 pos)
        {
            _pos = pos;
            _linked = new List<Node>();
        }
        public bool isLinked(Node node)
        {
            bool a = _linked.Find(x => x == node) != null;
            bool b = node._linked.Find(x => x == this) != null;
            if (a != b)
            {
                Debug.LogError("Graph Doesn't Macthed.");
            }
            return a;

        }
        public void LinkNode(Node node)
        {
            _linked.Add(node);
            node._linked.Add(node);
        }
        public void UnlinkNode(Node node)
        {
            _linked.Remove(node);
            node._linked.Remove(this);
        }
    }

    public List<Node> nodes;

    public void AddNode(Node node)
    {
        nodes.Add(node);
    }

    public Node findNode(Vector2 pos)
    {
        foreach (Node n in nodes)
        {
            if (n.Pos == pos)
            {
                return n;
            }
        }
        Debug.Log("Can't Find Nav Node");
        return null;
    }
}


public class NavMap : MonoBehaviour
{
    private NavGraph MapData;

    private void Start()
    {
        
    }
    
}

