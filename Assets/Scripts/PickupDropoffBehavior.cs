using UnityEngine;
using System.Collections.Generic;

public class PickupDropoffBehavior : MonoBehaviour
{
    public List<Transform> pickupLocs = new List<Transform>();
    public List<Transform> dropoffLocs = new List<Transform>();
    private Transform currentPULoc;
    private Transform currentDOLoc;
    public GameObject passenger;
    public bool passengerSpawned = false;

    private CarBehavior carBehavior;

    private void Start()
    {
        carBehavior = FindFirstObjectByType<CarBehavior>();
    }

    private void Update()
    {
        if (!passengerSpawned)
            SpawnPassenger();

        if(carBehavior.passengerLoaded)
        {
            InitiateDropoff();
        }
    }

    private void SpawnPassenger()
    {
        passengerSpawned = true;
        currentPULoc = pickupLocs[Random.Range(0, pickupLocs.Count)];
        currentDOLoc = dropoffLocs[Random.Range(0, dropoffLocs.Count)];
        Instantiate(passenger, currentPULoc);
    }

    private void InitiateDropoff()
    {
        currentDOLoc.GetComponent<DropoffPoint>().Activate();
    }
}
