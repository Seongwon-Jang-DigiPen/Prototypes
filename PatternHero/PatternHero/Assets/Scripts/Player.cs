using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct PlayerState
{
    public int HP;
    public float Power;
    public float Fever;
}

public class Player : IListener
{
    public PlayerState PlayerState;
    public Pattern.AttackManager AttackManager;
    public bool Attackable => AttackManager.Attackable;

    public Player()
    {
        AttackManager = new Pattern.AttackManager();
    }

    public void initListener()
    {
        TurnManager.Instance.AddListener(EVENT_TYPE.PLAYER_START_ATTACK, this);
    }

    public void OnEvent(EVENT_TYPE event_Type, Component sender, object Param = null)
    {
        switch (event_Type)
        {
           case EVENT_TYPE.PLAYER_START_TURN:
                StartTurn();
                break;
            }
    }

    private void StartTurn()
    {
        
    }



}
