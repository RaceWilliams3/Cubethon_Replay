using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 500f;
    public float sidewaysForce = 100f;


    //Movement Functions
    public void MoveLeft()
    {
        rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void MoveRight()
    {
        rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    //Resets position to start (not used right now but might be useful later)
    public void ResetPosition()
    {
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);
        GetComponent<Transform>().eulerAngles = new Vector3(0f, 0f, 0f);
        transform.position = new Vector3(0.0f, 1.12f, 0.0f);
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        
    }
}
