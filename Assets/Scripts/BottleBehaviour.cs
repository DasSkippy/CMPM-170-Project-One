using UnityEngine;

public class BottleBehaviour : MonoBehaviour
{
    private DrunkBar drunkBar;
    public float addDrunk;

    void Start()
    {
        drunkBar = FindFirstObjectByType<DrunkBar>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            Debug.Log("triggered");
            if (drunkBar != null)
            {
                drunkBar.GetDrunk(addDrunk);
                Destroy(gameObject);
            }
        }
    }
}
