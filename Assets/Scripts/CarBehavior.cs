using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    private Rigidbody myRb;
    public float speed = 10f;
    public float turnSpeed = 100f;
    public float maxSpeed = 10f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Drive();
        Turn();
    }

    private void Drive()
    {
        float move = Input.GetAxis("Vertical");
        Vector3 myVelocity = transform.forward * speed * move;
        myVelocity.y = myRb.linearVelocity.y;

        myRb.linearVelocity = myVelocity;
    }

    //ChatGPT assist to get car to turn only when moving
    private void Turn()
    {
        float turn = Input.GetAxis("Horizontal");

        // Get forward speed along the car's forward axis
        float forwardSpeed = Vector3.Dot(myRb.linearVelocity, transform.forward);

        // Scale turn by speed
        float speedFactor = Mathf.Clamp01(Mathf.Abs(forwardSpeed) / maxSpeed);

        float turnAmount = turn * turnSpeed * speedFactor * Time.deltaTime;

        // Reverse steering if going backward
        if (forwardSpeed < 0) turnAmount = -turnAmount;

        transform.Rotate(Vector3.up, turnAmount);
    }
}
