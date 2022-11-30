using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float sizeVary;

    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Transform>().localScale += new Vector3(Random.Range(-sizeVary, sizeVary), Random.Range(-sizeVary, sizeVary), 0);
    }
}
