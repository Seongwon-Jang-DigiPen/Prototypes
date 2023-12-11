using System.Collections;
using System.Collections.Generic;
using Pattern;
using UnityEngine;

namespace Pattern { 

    public class AttackManager : IListener
    {
        public List<PatternNode> LinkedNode { get { return _linkedNode; } }
        private List<PatternNode> _linkedNode = new List<PatternNode>();
        public bool Attackable = false;
        public AttackManager()
        {
            TurnManager.Instance.AddListener(EVENT_TYPE.PLAYER_START_TURN, this);
            TurnManager.Instance.AddListener(EVENT_TYPE.PLAYER_START_ATTACK, this);
        }


        public void LinkingNode(PatternNode pb)
        {
            _linkedNode.Add(pb);
        }
        
        public void ResetNode()
        {
            foreach (PatternNode button in _linkedNode)
            {
                button.IsPassed = false;
            }
            _linkedNode.Clear();
        }

        public void OnEvent(EVENT_TYPE event_Type, Component sender, object Param = null)
        {
            switch (event_Type)
            {
                case EVENT_TYPE.PLAYER_START_TURN:
                    Attackable = true;
                    break;
                case EVENT_TYPE.PLAYER_START_ATTACK:
                    Attackable = false;
                    break;
            }
        }
    }
}
