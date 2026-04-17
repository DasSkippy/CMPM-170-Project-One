using UnityEngine;
using UnityEngine.UI;

public class CarBehavior : MonoBehaviour
{
    private Rigidbody myRb;
    public float speed = 10f;
    public float turnSpeed = 100f;
    public float maxSpeed = 10f;

    public bool passengerLoaded = false;
    public Image passengerImage;

    [SerializeField] private AudioSource revAudioSource;
    [SerializeField] private AudioSource steadyAudioSource;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        // carAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Drive();
        Turn();
        HandleDrivingSound();
        HandleRevSound();
    }

    private void Drive()
    {
        float move = Input.GetAxis("Vertical");
        Vector3 myVelocity = transform.forward * speed * move;
        myVelocity.y = myRb.linearVelocity.y;

        myRb.linearVelocity = myVelocity;

        //play sound FX
        // SoundFXManager.instance.PlaySoundFXClip(drivingSound, transform, 1f);
    }

    //ChatGPT assisted with Turn() to get car to turn only when moving
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

    //consistent driving sound when car is driving regularly
    private void HandleDrivingSound()
    {
        float moveInput = Input.GetAxis("Vertical");
        bool isMoving = Mathf.Abs(moveInput) > 0.1f;

        if (isMoving)
        {
            if (!steadyAudioSource.isPlaying)
            {
                steadyAudioSource.Play();
            }
        }
        else
        {
            if (steadyAudioSource.isPlaying)
            {
                steadyAudioSource.Stop();
            }
        }
    }
    
    //adding sound when car turns
    private void HandleRevSound()
    {
        float turnInput = Input.GetAxis("Horizontal");
        float moveInput = Input.GetAxis("Vertical");

        bool isTurning = Mathf.Abs(turnInput) > 0.1f;
        bool isMoving = Mathf.Abs(moveInput) > 0.1f;

        if (isTurning && isMoving)
        {
            if (!revAudioSource.isPlaying)
            {
                revAudioSource.Play();
            }
        }
        else
        {
            if (revAudioSource.isPlaying)
            {
                revAudioSource.Stop();
            }
        }
    }

    public void LoadPassenger(PassengerInfo currentInfo)
    {
        passengerImage.gameObject.SetActive(true);
        passengerLoaded = true;
        passengerImage.sprite = currentInfo.image;
    }
}
