using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStartPlatform : MonoBehaviour
{
    [SerializeField]
    private CarController _Car;
    private PlayerController _Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _Player = other.GetComponent<PlayerController>();
        _Player.PlayerCanMove = false;
        _Car.CanMove = true;

    }
}
