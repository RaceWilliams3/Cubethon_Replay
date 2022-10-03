using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour, IDroneControl
{
    public bool hasAttacked;

    public void Execute(Drone drone)
    {
        if(!hasAttacked)
        {
            //Debug.Log("Drone: " + drone.id + " Attacked");
            Instantiate(drone.obstacle, drone.transform.position, Quaternion.identity);
            hasAttacked = true;
        } 
    }
}

public class Move : MonoBehaviour, IDroneControl
{
    private float sideOffset;
    private float heightOffset;
    private float distOffset;

    private Vector3 targetPos;
    private Vector3 startPos;
    private Vector3 playerPos;

    public bool isMoving;
    private Drone _drone;

    private Vector3 createOffset()
    {
        sideOffset = Random.Range(-4, 4);
        heightOffset = Random.Range(5, 10);
        distOffset = Random.Range(50, 200);

        return new Vector3(sideOffset, heightOffset, distOffset);
    }
    

    public void Execute(Drone drone)
    {
        //Save drone info
        this._drone = drone;
        
        //Save current positions
        startPos = drone.transform.position;
        playerPos = drone.player.transform.position;

        //Find target pos absed on offsets
        targetPos = playerPos + createOffset();
        targetPos.x = Mathf.Clamp(targetPos.x, -4, 4);

        //move based off of player position and offset
        isMoving = true;
    }

    void Update()
    {
        if(isMoving)
        {
            var step = _drone.speed * Time.deltaTime;
            _drone.transform.position = Vector3.MoveTowards(_drone.transform.position, targetPos, step);
            if (Vector3.Distance(_drone.transform.position, targetPos) < 0.1)
                isMoving = false;
        }
    }

}