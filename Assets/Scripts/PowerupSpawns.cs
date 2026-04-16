using UnityEngine;
using System.Collections;

public class PowerupSpawns : MonoBehaviour
{
    public GameObject bottle;
    public GameObject MedBox;
    public Transform cityCorner1, cityCorner2;

    public int maxBottles;
    public int currentBottles;
    public float spawnRate;

    public int maxHealthPacks;
    public int currentHealthPacks;
    public float healthPackSpawnRate;

    private void Start()
    {
        SpawnPowerup();
        StartCoroutine(HealthPackSpawnLoop());
    }
    
    private IEnumerator HealthPackSpawnLoop()
    {
        while (true)
        {
            if (currentHealthPacks < maxHealthPacks)
            {
                SpawnHealthPack();
            }
            yield return new WaitForSeconds(healthPackSpawnRate);
        }
    }

    private IEnumerator SpawnTime(float time)
    {
        yield return new WaitForSeconds(time);
        if(currentBottles < maxBottles)
            SpawnPowerup();
    }

    void SpawnPowerup()
    {

        Vector3 randomPos = new Vector3(
            Random.Range(cityCorner1.position.x, cityCorner2.position.x),
            50f,
            Random.Range(cityCorner1.position.z, cityCorner2.position.z)
        );

        // Debug.Log(randomPos);

        RaycastHit hit;
        if (Physics.Raycast(randomPos, Vector3.down, out hit, 100f))
        {
            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Road"))
            {
                Instantiate(bottle, hit.point, Quaternion.identity);
                Debug.Log("bottle spawned");
                currentBottles++;

            }
        }
        StartCoroutine(SpawnTime(spawnRate));
    }
    
    void SpawnHealthPack()
    {
        Vector3 spawnPoint = new Vector3(
            Random.Range(cityCorner1.position.x, cityCorner2.position.x),
            50f,
            Random.Range(cityCorner1.position.z, cityCorner2.position.z)
        );
        
        
        RaycastHit hit;

        if (Physics.Raycast(spawnPoint, Vector3.down, out hit, 100f))
        {
            // + new Vector3(0f, healthPackHeightOffset, 0f)
            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Road"))
            {
                Instantiate(MedBox, hit.point, Quaternion.identity);
                Debug.Log("Health pack spawned");
                currentHealthPacks++;
            }

        }
    }
}
