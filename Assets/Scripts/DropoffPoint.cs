using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class DropoffPoint : MonoBehaviour
{
    public bool isActiveDropoff = false;
    private GameManager gameManager;
    private PickupDropoffBehavior pickupDropoffBehavior;
    private CarBehavior carBehavior;
    private DrunkBar drunkBar;
    public AudioClip close;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        pickupDropoffBehavior = FindFirstObjectByType<PickupDropoffBehavior>();
        carBehavior = FindFirstObjectByType<CarBehavior>();
        drunkBar = FindFirstObjectByType<DrunkBar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isActiveDropoff && other.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            Deactivate();
        }
    }

    private void Deactivate()
    {
        isActiveDropoff = false;
        gameManager.passengersDroppedOff++;
        drunkBar.IncreaseDifficulty();
        pickupDropoffBehavior.passengerSpawned = false;
        transform.GetChild(0).gameObject.SetActive(false);
        carBehavior.passengerLoaded = false;
        carBehavior.passengerImage.gameObject.SetActive(false);
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(close);
    }

    public void Activate()
    {
        isActiveDropoff = true;
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
