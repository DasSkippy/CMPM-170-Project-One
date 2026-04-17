using UnityEngine;

public class SunCycle : MonoBehaviour
{
    public float rotationSpeed = 50f;

    public Material daySkybox;
    public Material nightSkybox;
    private Light sunlight;

    public GameObject headlights;

    private void Start()
    {
        sunlight = GetComponent<Light>();
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f);

        float xRotation = transform.eulerAngles.x;

        //Day
        if (xRotation > 0f && xRotation < 180f)
        {
            if(headlights != null)
                headlights.SetActive(false);
            sunlight.intensity = 2;
            if (RenderSettings.skybox != daySkybox)
            {
                RenderSettings.skybox = daySkybox;
                DynamicGI.UpdateEnvironment();
            }
        }
        else
        {
            //Night
            if(headlights != null)
                headlights.SetActive(true);

            sunlight.intensity = 0;
            if (RenderSettings.skybox != nightSkybox)
            {
                RenderSettings.skybox = nightSkybox;
                DynamicGI.UpdateEnvironment();
            }
        }
    }
}