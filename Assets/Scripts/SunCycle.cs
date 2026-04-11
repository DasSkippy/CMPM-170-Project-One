using UnityEngine;

public class SunCycle : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f);
    }
}
