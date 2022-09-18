using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement movement;
    private InputHandler _inputHandler;

    void Start()
    {
        _inputHandler = FindObjectOfType<InputHandler>();
    }

    void OnCollisionEnter(Collision collsionInfo)
    {
        if (collsionInfo.collider.tag == "Obstacle")
        {
            _inputHandler.Replay();
            //FindObjectOfType<GameManager>().EndGame();

        }
    }
}
