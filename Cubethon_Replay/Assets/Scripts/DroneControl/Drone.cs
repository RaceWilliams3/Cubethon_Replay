using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public int id;
    public float speed;
    public GameObject player;
    public GameObject obstacle;

    void Awake()
    {
        //player = FindObjectOfType<Player>();
    }

    public void ApplyStrategy(IDroneControl strategy)
    {
        strategy.Execute(this);
    }
}
