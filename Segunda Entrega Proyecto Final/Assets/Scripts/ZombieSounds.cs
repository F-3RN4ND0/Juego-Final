using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSounds : MonoBehaviour
{
    public float _fTimeBetweenSounds = 5f;
    public AudioClip[] _ZombieSounds;
    AudioSource _AudioSource;

    private void Awake()
    {
        _AudioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        Invoke("PlaySound", Random.Range(0, 5.0f));
    }

    void PlaySound()
    {
        int liRandmAudioIndex = Random.Range(0, _ZombieSounds.Length);
        _AudioSource.clip = _ZombieSounds[liRandmAudioIndex];
        _AudioSource.Play();

        Invoke("PlaySound", _AudioSource.clip.length + _fTimeBetweenSounds);
    }
}
