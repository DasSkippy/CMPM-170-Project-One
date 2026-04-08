using Unity.VisualScripting;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public float distance;
    public float mouseSensitivity;
    public float scrollSpeed;
    public Transform car;

    float xRotation = 20f;
    float yRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        MoveCam();

        Zoom();
    }

    private void MoveCam()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -30f, 70f);

        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);

        Vector3 offset = rotation * new Vector3(0, 0, -distance);

        transform.position = car.position + offset;
        transform.LookAt(car);
    }

    private void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * scrollSpeed;

        distance = Mathf.Clamp(distance, 0.1f, 5f);
    }
}
