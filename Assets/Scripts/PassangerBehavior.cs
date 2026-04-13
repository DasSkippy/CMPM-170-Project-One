using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class PassengerInfo
{
    public string name;
    public Sprite image;
};


public class PassangerBehavior : MonoBehaviour
{
    public List<PassengerInfo> passengerID = new List<PassengerInfo>();
    private PassengerInfo currentID;
    private CarBehavior carBehavior;
    private Transform car;

    public void Start()
    {
        currentID = passengerID[Random.Range(0, passengerID.Count)];
        carBehavior = FindFirstObjectByType<CarBehavior>();
        car = GameObject.Find("Truck").transform;
    }

    public void Update()
    {
        FaceCar();
    }

    private void FaceCar()
    {
        Vector3 direction = car.position - transform.position;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Car") && !carBehavior.passengerLoaded)
        {
            PickupPassenger();
        }
    }


    private void PickupPassenger()
    {
        gameObject.SetActive(false);
        carBehavior.LoadPassenger(currentID);
        Debug.Log("Picked up " + currentID.name);
    }
}
