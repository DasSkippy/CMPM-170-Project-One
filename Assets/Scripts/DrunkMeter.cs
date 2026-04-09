using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DrunkMeter : MonoBehaviour
{
    public Slider slider;
    public float maxDrunkValue = 100;
    public float currentDrunkValue;
    public float drunkSlowdownThreshold = 3f;
    public float drunkDecreaseRate = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentDrunkValue = maxDrunkValue;
        slider.maxValue = maxDrunkValue;
        slider.value = currentDrunkValue;
    }

    // Update is called once per frame
    void Update()
    {   
        drunkDecreaseRate = Mathf.MoveTowards(drunkDecreaseRate, 0f, drunkSlowdownThreshold* Time.deltaTime);
        currentDrunkValue -= drunkDecreaseRate * Time.deltaTime;

        slider.value = currentDrunkValue;

    }
}
