using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour, IListener
{
    public static TurnManager Instance
    {
        get { return instance; }
        set { }
    }

    public enum TURNSTATE
    {
        PLAYERTURN,
        ENEMYTURN
    }

    private Dictionary<EVENT_TYPE, List<IListener>> Listeners = new Dictionary<EVENT_TYPE, List<IListener>>();
    private TURNSTATE _currState;
    public TURNSTATE CurrState { get { return _currState; } private set { _currState = value; } }
    public List<Monster> monsters;
    public Player player;

  

    private static TurnManager instance = null;
    
   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(this);
            SceneManager.sceneLoaded += SceneLoaded;
        }

    }

    private void Start()
    {
        player = new Player();


        AddListener(EVENT_TYPE.TURN_START, this);
        AddListener(EVENT_TYPE.PLAYER_END_ATTACK, this);
        AddListener(EVENT_TYPE.ENEMY_END_ATTACK, this);
        AddListener(EVENT_TYPE.PLAYER_DEAD, this);
        AddListener(EVENT_TYPE.ENEMY_DEAD, this);
        AddListener(EVENT_TYPE.ALL_ENEMY_DEAD, this);

        PostNotification(EVENT_TYPE.TURN_START, this);
       

        
    }

    public void OnEvent(EVENT_TYPE event_Type, Component sender, object Param = null)
    {
        switch (event_Type)
        {
            case EVENT_TYPE.TURN_START:
                ChangeTurnState(TURNSTATE.PLAYERTURN);
                break;
            case EVENT_TYPE.ENEMY_END_ATTACK:
                ChangeTurnState(TURNSTATE.PLAYERTURN);
                break;
            case EVENT_TYPE.PLAYER_END_ATTACK:
                ChangeTurnState(TURNSTATE.ENEMYTURN);
                break;
            case EVENT_TYPE.ENEMY_DEAD:

                break;
            case EVENT_TYPE.PLAYER_DEAD:

                break;
            case EVENT_TYPE.ALL_ENEMY_DEAD:
                break;
        }
    }

    private void ChangeTurnState(TURNSTATE state)
    {
        switch (state)
        {
            case TURNSTATE.PLAYERTURN:
                PostNotification(EVENT_TYPE.PLAYER_START_TURN, this);
                break;
            case TURNSTATE.ENEMYTURN:
                PostNotification(EVENT_TYPE.ENEMY_START_TURN, this);
                break;
        }
        CurrState = state;
    }


    public void AddListener(EVENT_TYPE eventType, IListener listener)
    {
        List<IListener> listenList = null;

        if (Listeners.TryGetValue(eventType, out listenList) == true)
        {
            listenList.Add(listener);
            return;
        }
        listenList = new List<IListener>();
        listenList.Add(listener);
        Listeners.Add(eventType, listenList);

    }

    public void PostNotification(EVENT_TYPE eventType, Component Sender, object Param = null)
    {
        List<IListener> listenList = null;

        if (Listeners.TryGetValue(eventType, out listenList) == false)
        {
            return;
        }

        for (int i = 0; i < listenList.Count; ++i)
        {
            if (listenList[i].Equals(null) == false)
            {
                listenList[i].OnEvent(eventType, Sender, Param);
            }
            else
            {
                Debug.Log("In TurnManager, listenList have null");
            }
        }
    }

    public void RemoveEvent(EVENT_TYPE eventType)
    {
        Listeners.Remove(eventType);
    }

    public void RemoveRedundancies()
    {
        Dictionary<EVENT_TYPE, List<IListener>> tempListeners = new Dictionary<EVENT_TYPE, List<IListener>>();
        foreach (KeyValuePair<EVENT_TYPE, List<IListener>> item in Listeners)
        {
            for (int i = item.Value.Count - 1; i >= 0; i--)
            {
                if (item.Value[i].Equals(null))
                {
                    item.Value.RemoveAt(i);
                }
            }
            if (item.Value.Count > 0)
            {
                tempListeners.Add(item.Key, item.Value);
            }
        }
        Listeners = tempListeners;
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RemoveRedundancies();
    }
}
