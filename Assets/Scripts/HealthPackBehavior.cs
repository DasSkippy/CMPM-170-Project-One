using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class HealthPackBehavior : MonoBehaviour
{
    private DamageBar damageBar;
    public float healAmount;
    private bool collected = false;
    public AudioClip wrench;

    private PowerupSpawns powerupSpawns;
    
    private void Start()
    {
        damageBar = FindFirstObjectByType<DamageBar>();
        powerupSpawns = FindFirstObjectByType<PowerupSpawns>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            if (damageBar != null && !collected)
            {
                collected = true;
                damageBar.Heal(healAmount);
                Destroy(gameObject);
                powerupSpawns.currentHealthPacks--;
                Debug.Log("health pack collected");
                GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(wrench);
            }
        }
    }

}