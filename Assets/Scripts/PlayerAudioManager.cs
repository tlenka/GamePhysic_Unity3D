using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private AudioSource _playerAudioSource;
    [SerializeField] private AudioClip _jumpAudioClip;
    [SerializeField] private AudioClip _landingAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        _player.JumpEvent += Player_JumpEvent;
        _player.LandingEvent += Player_LandingEvent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //JumpEvent handler
    private void Player_JumpEvent()
    {
        _playerAudioSource.PlayOneShot(_jumpAudioClip);
    }

    //LandingEvent handler
    private void Player_LandingEvent()
    {
        _playerAudioSource.PlayOneShot(_landingAudioClip);
    }
}
