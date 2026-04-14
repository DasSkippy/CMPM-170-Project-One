using UnityEngine;

public class NewCameraPosition : MonoBehaviour
{
    public Transform cameraPosition;
    private Animator myAnimator;

    private bool shakeCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        myAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
        transform.rotation = cameraPosition.rotation;

        myAnimator.SetBool("shake", shakeCamera);

        if (Input.GetKeyDown(KeyCode.P))
        {
            shakeCamera = !shakeCamera;
        }
    }
}
