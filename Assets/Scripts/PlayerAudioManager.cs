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

    // Start is called before the first frame update
    void Start()
    {
        _player.StopWalkingEvent += Player_StopWalkingEvent;
        _player.WalkingEvent += Player_WalkingEvent;
        _player.LandingEvent += Player_LandingEvent;
        _player.JumpEvent += Player_JumpEvent;
        
    }

    private void Player_StopWalkingEvent()
    {
        _playerAudioSource.PlayOneShot(_stopWalkingAudioClip);
    }

    private void Player_WalkingEvent()
    {
        _playerAudioSource.PlayOneShot(_walkingAudioClip);
    }

    //LandingEvent handler
    private void Player_LandingEvent()
    {
        _playerAudioSource.PlayOneShot(_landingAudioClip);
    }

    //JumpEvent handler
    private void Player_JumpEvent()
    {
        _playerAudioSource.PlayOneShot(_jumpAudioClip);
    }

   
}
