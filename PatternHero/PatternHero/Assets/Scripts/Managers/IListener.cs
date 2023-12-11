using UnityEngine;


public enum EVENT_TYPE
{
  TURN_START, PLAYER_START_TURN, PLAYER_START_ATTACK, PLAYER_END_ATTACK, ENEMY_START_TURN, ENEMY_START_ATTACK, ENEMY_END_ATTACK, ENEMY_DEAD, PLAYER_DEAD, ALL_ENEMY_DEAD
}

public interface IListener
{
    public void OnEvent(EVENT_TYPE event_Type, Component sender, object Param = null);
}
