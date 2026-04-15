using UnityEngine;

public class BottleBehaviour : MonoBehaviour
{
    private DrunkBar drunkBar;
    public float addDrunk;
    private bool collected = false;

    private PowerupSpawns powerupSpawns;

    void Start()
    {
        drunkBar = FindFirstObjectByType<DrunkBar>();
        powerupSpawns = FindFirstObjectByType<PowerupSpawns>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            if (drunkBar != null && !collected)
            {
                drunkBar.GetDrunk(addDrunk);
                Destroy(gameObject);
                powerupSpawns.currentBottles--;
                collected = true;
                Debug.Log("bottle collected");
            }
        }
    }
}
