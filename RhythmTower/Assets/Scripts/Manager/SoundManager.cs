using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Property
    public static SoundManager Instance { get { return _instance; } }
    private static SoundManager _instance = null;


    private AudioSource _BGMSource;
    private List<AudioSource> _SFX;

    [SerializeField]
    private int _StartAudioSourceNum = 5;

    #endregion

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
            return;
        }
        Destroy(this.gameObject);
    }

    void Start()
    {
        for(int i = 0; i < _StartAudioSourceNum; ++i)
        {
            GenerateNewAudioSource();
        }
    }

    
    
    AudioSource GetUnplayAudioSource()
    {
        for(int i = 0; i < _StartAudioSourceNum; ++i)
        {
            if(_SFX[i].isPlaying == false)
            {
                return _SFX[i];
            }
        }
        return GenerateNewAudioSource();
    }

    AudioSource GenerateNewAudioSource()
    {
        GameObject obj = new GameObject($"SFX{_SFX.Count}");
        obj.transform.SetParent(gameObject.transform);
        AudioSource AS = obj.AddComponent<AudioSource>();
        _SFX.Add(obj.GetComponent<AudioSource>());
        return AS;
    }
}
