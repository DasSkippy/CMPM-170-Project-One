using UnityEngine;
using System.Collections;

public class DrunkBar : MonoBehaviour
{
    public Transform drunkMeter;
    public float drunkAmount;
    public float drunkRate;
    public float drunkTime;
    public float drunkMaxAmount = 100f;

    private GameManager gameManager;

    private void Start()
    {
        drunkAmount = drunkMaxAmount;
        StartCoroutine(GetSober(drunkTime));
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
            gameManager.Lose();
        }
    }

    private IEnumerator GetSober(float delay)
    {
        yield return new WaitForSeconds(delay);
        IdleSober();
    }

    private void IdleSober()
    {
        drunkAmount -= drunkRate;
        StartCoroutine(GetSober(drunkTime));
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
}
