using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private AudioSource _playerAudioSource;
    [SerializeField] private AudioClip _jumpAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        _player.JumpEvent += player_JumpEvent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //JumpEvent handler
    private void player_JumpEvent()
    {
        _playerAudioSource.PlayOneShot(_jumpAudioClip);
    }
}
