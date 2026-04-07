using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    private Rigidbody myRb;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("drive forward");
            myRb.linearVelocity = transform.forward * speed;
        }
    }
}
