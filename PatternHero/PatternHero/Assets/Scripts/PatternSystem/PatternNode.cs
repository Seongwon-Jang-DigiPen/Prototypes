using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;
namespace Pattern {
    public class PatternNode : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler
    {
        static bool NodePressed = false;

        [SerializeField]
        Vector2Int _pos = Vector2Int.zero;
        Vector2Int Pos { get { return _pos; } }
        public float Hp = 100;

        public bool IsPassed { get { return _isPassed; } set { _isPassed = value; } }
        private bool _isPassed = false;


        private bool IsPassable()
        {
            return IsPassed == false;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (NodePressed == true)
            {
                TurnManager.Instance.PostNotification(EVENT_TYPE.PLAYER_START_ATTACK, this);
                NodePressed = false;
            }
            //End Draw
            Debug.Log($"On Point Up {gameObject.name}");          
            //send to PatternManager
         }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log($"On Point Enter {gameObject.name}");
            if (NodePressed == false) return;

            TouchNode();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log($"On Point Down {gameObject.name}");
            Debug.Log("Start Draw");
            NodePressed = true;
            TouchNode();
        }
        private void TouchNode()
        {
            if(IsPassable() == false) { return; }
            TurnManager.Instance.player.AttackManager.LinkingNode(this);

            IsPassed = true;
        }
    }
}