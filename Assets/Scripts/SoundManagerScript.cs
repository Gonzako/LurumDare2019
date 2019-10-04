using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using System; 
public class SoundManagerScript : MonoBehaviour
{
    public float SourcePool;

    private List<GameObject> sounds = new List<GameObject>();

    public void PlaySound(AudioClip clip)
    {
        AudioSource _AS;
        for (int i = 0; i < sounds.Count; i++)
        {
            _AS = sounds[i].GetComponent<AudioSource>();
            if (!_AS.isPlaying)
            {
                _AS.clip = clip;
                _AS.Play();
                return;
            }
        }
        GameObject _obj = CreateSoundObject();
        _AS = _obj.GetComponent<AudioSource>();
        _AS.clip = clip;
        _AS.Play();
    }
    private void SetupPool()
    {
        for (int i = 0; i < SourcePool; i++)
        {
            CreateSoundObject();
        }
    }

    private GameObject CreateSoundObject()
    {
        GameObject _gameObject = new GameObject("Sound");
        _gameObject.AddComponent<AudioSource>();
        sounds.Add(_gameObject);
        _gameObject.transform.parent = this.transform;
        return _gameObject;
    }
    #region UnityAPI
    private void Awake()
    {
        SetupPool();
    }


    #endregion

}
