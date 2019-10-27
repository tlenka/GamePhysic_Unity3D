using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private AudioSource _playerAudioSource;

    [SerializeField] private AudioClip _jumpAudioClip;
    [SerializeField] private AudioClip _landingAudioClip;
    [SerializeField] private AudioClip _walkingAudioClip;
    [SerializeField] private AudioClip _stopWalkingAudioClip;

    private Dictionary<string, AudioClip> AudioClipDictionary;

    // Start is called before the first frame update
    void Start()
    {
        AudioClipDictionary = new Dictionary<string, AudioClip>()
        {
            { "jumpAudio", _jumpAudioClip },
            { "landingAudio", _landingAudioClip },
            { "walkingAudio", _walkingAudioClip },
            { "stopWalkingAudio", _stopWalkingAudioClip }
        };

        _player.AudioEvent += Player_AudioEvent;
    }

    // AudioEvent handler
    private void Player_AudioEvent(string audioName)
    {
        _playerAudioSource.PlayOneShot(AudioClipDictionary[audioName]);
    }
}
