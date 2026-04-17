using UnityEngine;
using System.Collections;

public class DrunkBar : MonoBehaviour
{
    public Transform drunkMeter;
    public float drunkAmount;
    public float drunkRate;
    public float drunkRateIncrease = 1.10f;
    public float drunkTime;
    public float drunkMaxAmount = 100f;

    private GameManager gameManager;

    private void Start()
    {
        drunkAmount = drunkMaxAmount;
        StartCoroutine(GetSober());
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Update()
    {
        SetDrunkBar();
        if (drunkAmount >= drunkMaxAmount)
        {
            drunkAmount = drunkMaxAmount;
        }
        if (drunkAmount <= 0)
        {
            drunkAmount = 0;
            gameManager.Lose(0);
        }
    }

    private IEnumerator GetSober()
    {
        while (true)
        {
            yield return new WaitForSeconds(drunkTime);
            Debug.Log("sober");
            drunkAmount -= drunkRate;
        }
    }

    public void GetDrunk(float addDrunk)
    {
        drunkAmount += addDrunk;
        Debug.Log("drunk called");
    }

    private void SetDrunkBar()
    {
        float drunkScalex = 6.4f * (drunkAmount / drunkMaxAmount);
        if (drunkScalex > 6.4f)
            drunkScalex = 6.4f;
        drunkMeter.localScale = new Vector3(drunkScalex, 1f, 1f);
    }

    public void IncreaseDifficulty()
    {
        drunkRate = drunkRate * drunkRateIncrease;
    }
}
