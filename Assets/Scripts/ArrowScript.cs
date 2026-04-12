using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private Transform car;

    private void Start()
    {
        car = GameObject.Find("Truck").transform;
    }

    void Update()
    {
        Vector3 direction = car.position - transform.position;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
    }
}
