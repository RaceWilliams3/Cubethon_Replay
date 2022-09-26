using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private bool _isReplaying;
    private bool _isRecording;
    private PlayerMovement _playerController;
    private Command _buttonA, _ButtonD;

    void Start()
    {
        Debug.Log("Input Handler Started");
        _invoker = gameObject.AddComponent<Invoker>();
        _playerController = FindObjectOfType<PlayerMovement>();

        _playerController.ResetPosition();
        _isReplaying = false;
        _isRecording = true;
        _invoker.Record();

        _buttonA = new MoveLeft(_playerController);
        _ButtonD = new MoveRight(_playerController);
    }

    void FixedUpdate()
    {
        if (!_isReplaying && _isRecording)
        {
            if (Input.GetKey("a"))
            {
                _invoker.ExecuteCommand(_buttonA);
            }
            if (Input.GetKey("d"))
            {
                _invoker.ExecuteCommand(_ButtonD);
            }
        }
    }

    public bool getReplaying()
    {
        return _isReplaying;
    }

    public void Replay()
    {
        //Reset Player
        _playerController.ResetPosition();
        Debug.Log("Reset");

        Debug.Log("Replay");
        //Replay
        _isRecording = false;
        _isReplaying = true;
        _invoker.Replay();
    }
}
