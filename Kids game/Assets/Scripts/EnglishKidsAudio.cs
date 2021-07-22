using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnglishKidsAudio : MonoBehaviour
{
    public AudioClip[] _audios;
    private AudioSource _audioSource;
    //плохой код тоже код =)
    public void CorrectAnswer()
    {
        _audioSource.clip = _audios[0];
        _audioSource.Play();
    }

    public void McRed()
    {
        _audioSource.clip = _audios[1];
        _audioSource.Play();
    }

    public void McYellow()
    {
        _audioSource.clip = _audios[2];
        _audioSource.Play();
    }

    public void Pick()
    {
        _audioSource.clip = _audios[3];
        _audioSource.Play();
    }

    public void WrongAnswer()
    {
        _audioSource.clip = _audios[4];
        _audioSource.Play();
    }
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audios = Resources.LoadAll<AudioClip>("Audios");
    }
}
