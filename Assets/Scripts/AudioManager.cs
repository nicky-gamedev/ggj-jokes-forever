using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audios;
    private Dictionary<string, AudioClip> _audioDB = new();
    [SerializeField] private AudioSource[] _sources;
    
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if(_instance == null)
            {
                var go = new GameObject("Audio Manager");
                _instance = go.AddComponent<AudioManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        foreach (var audio in _audios)
        {
            _audioDB.Add(audio.name, audio);
        }
    }

    public void PlayOneShot(string name, int index)
    {
        _sources[index].clip = _audioDB[name];
        _sources[index].loop = false;
        _sources[index].Play();
    }

    public void PlayLoop(string name, int index)
    {
        _sources[index].clip = _audioDB[name];
        _sources[index].loop = true;
        _sources[index].Play();
    }

    public void PlayRandom(string name, int index, int maxAudios = 3)
    {
        _sources[index].clip = _audioDB[$"{name}{Random.Range(1, maxAudios)}"];
    }
}
