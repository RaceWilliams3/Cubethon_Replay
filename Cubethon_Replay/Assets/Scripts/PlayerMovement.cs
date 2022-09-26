using UnityEngine;

public class PlayerMovement : Subject
{

    public Rigidbody rb;

    public float forwardForce = 500f;
    public float sidewaysForce = 100f;

    private ConffetiController _conControl;

    void Awake()
    {

        foreach (var controller in FindObjectsOfType(typeof(ConffetiController)) as Observer[])
        {
            Attach(controller);
            Debug.Log("Attached");
        }
    }

    void OnEnable()
    {
        if (_conControl)
            Attach(_conControl);
    }

    void OnDisable()
    {
        if (_conControl)
            Detach(_conControl);
    }

    public void MoveLeft()
    {
        rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void MoveRight()
    {
        rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void ResetPosition()
    {
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);
        GetComponent<Transform>().eulerAngles = new Vector3(0f, 0f, 0f);
        transform.position = new Vector3(0.0f, 1.12f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        
    }

    void Update()
    {
        if (Input.GetKeyDown("down"))
            NotifyObservers();
    }
}
