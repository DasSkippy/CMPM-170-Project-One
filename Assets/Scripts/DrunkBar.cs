using UnityEngine;
using System.Collections;

public class DrunkBar : MonoBehaviour
{
    public Transform drunkMeter;
    public float drunkAmount;
    public float drunkRate;
    public float drunkTime;
    public float drunkMaxAmount = 100f;

    private void Start()
    {
        drunkAmount = drunkMaxAmount;
        StartCoroutine(GetSober(drunkTime));
    }

    private void Update()
    {
        SetDrunkBar();
        if (drunkAmount >= drunkMaxAmount)
        {
            drunkAmount = drunkMaxAmount;
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
        drunkMeter.localScale = new Vector3(6.4f * (drunkAmount / drunkMaxAmount), 1f, 1f);
    }
}
