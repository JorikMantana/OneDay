using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSounds : MonoBehaviour
{
    [SerializeField] private AudioSource[] soundObjets;
    [SerializeField] private AudioClip[] sounds;
    float _timerCount;
    float _randomTime;
    [SerializeField] private float _randomFloatOne;
    [SerializeField] private float _randomFloatTwo;

    private void Start()
    {
        GenerateRandomTimerCount();
    }

    private void FixedUpdate()
    {
        _timerCount += 1f * Time.deltaTime;
        if (_timerCount >= _randomTime)
        {
            PlayRandomSound();
            GenerateRandomTimerCount();
            _timerCount = 0;
        }
    }

    private void GenerateRandomTimerCount()
    {
        _randomTime = Random.Range(_randomFloatOne, _randomFloatTwo);
    }

    private void PlayRandomSound()
    {
        int _randomObjectIndex;
        int _randomSoundIndex;
        
        if (soundObjets.Length == 0)
        {
            Debug.LogError("ТЫ ЕБЛАН! ГДЕ БУДКА МИША?");
            return;
        }
        if (sounds.Length == 0)
        {
            Debug.LogError("ТЫ ЕБЛАН! МИШИ НЕТ!");
            return;
        }

        _randomObjectIndex = Random.Range(0, soundObjets.Length);
        _randomSoundIndex = Random.Range(0, sounds.Length);
        
        Debug.Log("Object: " + _randomObjectIndex);
        Debug.Log("Clip: " + _randomSoundIndex);

        soundObjets[_randomSoundIndex].clip = sounds[_randomSoundIndex];
       soundObjets[_randomObjectIndex].Play();
    }
}
