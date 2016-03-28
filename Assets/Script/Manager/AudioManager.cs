using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    private static GameObject _instance = null;

    [SerializeField]
    private AudioClip[] _clip;

    private AudioSource _source;

    void Awake()
    {
        if(_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

        _source = GetComponentInChildren<AudioSource>();
    }


    public void Play(int index, bool loop = false, float volume = 1.0f)
    {
        _source.clip = _clip[index];
        _source.loop = loop;
        _source.volume = volume;
        _source.Play();
    }
}
