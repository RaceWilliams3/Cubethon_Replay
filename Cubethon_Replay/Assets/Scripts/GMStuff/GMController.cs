using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float sidewaysForce = 100f;

    [Header("Cursor Stuff")]
    public GameObject cursor;
    public float restriction;
    public float sensitivity;
    private Transform cursorTrans;

    [Header("Spawning Obstacles")]
    public float spawnRate;
    public GameObject obstaclePreFab;
    private bool canSpawn;
    private float spawnTime;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cursorTrans = cursor.GetComponent<Transform>();
        canSpawn = true;
    }

    public void MoveLeft()
    {
        rb.AddForce(0, 0, -sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
    }

    public void MoveRight()
    {
        rb.AddForce(0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
    }

    void Update()
    {
        //Checking inputs and running movement functions
        if (Input.GetKey("a"))
        {
            MoveLeft();
        }
        if (Input.GetKey("d"))
        {
            MoveRight();
        }

        //Checking for cursor control inputs and moving the cursor
        if (Input.GetKey("w") && cursorTrans.position.x >= (-restriction + (cursorTrans.localScale.x / 2)))
        {
            cursorTrans.position -= new Vector3(sensitivity, 0, 0);
        }

        if (Input.GetKey("s") && cursorTrans.position.x <= (restriction - (cursorTrans.localScale.x / 2)))
        {
            cursorTrans.position += new Vector3(sensitivity, 0, 0);
        }

        //Updating the cursor z to match the game masters position
        cursorTrans.position = new Vector3(cursorTrans.position.x, cursorTrans.position.y, this.GetComponent<Transform>().position.z);


        //Need to switch to photon when made multiplayer
        if (Input.GetKey("space") && canSpawn && cursor.GetComponent<CursorController>().inObstacle == false)
        {
            spawnTime = Time.time;
            canSpawn = false;
            Instantiate(obstaclePreFab, cursorTrans.position, Quaternion.identity);
        }

        if (Time.time - spawnTime > spawnRate)
        {
            canSpawn = true;
        }
    }
}
