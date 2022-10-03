using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientStrategy : MonoBehaviour
{
    public GameObject _drone;
    public GameObject _player;
    private Drone _droneControl;
    private Attack _attack;
    private Move _move;

    public bool _isMoving;

    void Awake()
    {
        _isMoving = true;

        _move = _drone.AddComponent<Move>();
        _attack = _drone.AddComponent<Attack>();
        _droneControl = _drone.GetComponent<Drone>();
        

    }

    void Update()
    {
        if(_player.transform.position.z > _drone.transform.position.z)
        {
            _droneControl.ApplyStrategy(_move);
            _attack.hasAttacked = false;
        }
            
        if (_move.isMoving == false && _attack.hasAttacked == false)
        {
            
            _droneControl.ApplyStrategy(_attack);
        }
    }
}
