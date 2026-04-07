using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    private Rigidbody myRb;
    public float speed;
    public float turnSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Drive();
        }
        Turn();
    }

    private void Drive()
    {
        Debug.Log("drive forward");
        myRb.linearVelocity = transform.forward * speed;
    }

    private void Turn()
    {
        //Turn Left
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Turn Left");
            myRb.angularVelocity = transform.forward * turnSpeed;
        }

        //Turn Right
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Turn Right");
            myRb.angularVelocity = -transform.forward * turnSpeed;
        }
    }
}
