using UnityEngine;

public class SunCycle : MonoBehaviour
{
    public float rotationSpeed = 50f;

    public Material daySkybox;
    public Material nightSkybox;

    void Update()
    {
        // Rotate the sun (your original behavior)
        transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f);

        // Get current X rotation (0–360)
        float xRotation = transform.eulerAngles.x;

        // 🌅 Day when sun is above horizon
        if (xRotation > 0f && xRotation < 180f)
        {
            if (RenderSettings.skybox != daySkybox)
            {
                RenderSettings.skybox = daySkybox;
                DynamicGI.UpdateEnvironment();
            }
        }
        // 🌙 Night when sun is below horizon
        else
        {
            if (RenderSettings.skybox != nightSkybox)
            {
                RenderSettings.skybox = nightSkybox;
                DynamicGI.UpdateEnvironment();
            }
        }
    }
}