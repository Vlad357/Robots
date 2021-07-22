using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class EnglishKidsTape : MonoBehaviour
{

    private AudioSource _audio;
    private float _posY = 9;
    private float _time = 5;
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        TapeAnimation();
    }
    private void TapeAnimation()
    {
        PlayNewParts();
        transform.DOMoveY(_posY, _time, false);
        Invoke("PlayNewParts", _time);
    }
    private void PlayNewParts()
    {
        _audio.Play();
    }
}
