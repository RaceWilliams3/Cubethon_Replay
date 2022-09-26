using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float randomOffset;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = GetComponent<Transform>().position;
        randomOffset = Random.Range(-randomOffset, randomOffset);
        GetComponent<Transform>().position = startPos + new Vector3(randomOffset, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
