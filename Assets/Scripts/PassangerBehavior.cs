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

    public void Start()
    {
        //currentID = passengerID[Random.Range(0, passengerID.Count)];
        Debug.Log(passengerID.Count);
        currentID = passengerID[0];
        carBehavior = FindFirstObjectByType<CarBehavior>();
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
