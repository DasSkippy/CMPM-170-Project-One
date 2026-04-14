using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DrunkBlurController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DrunkBar drunkBar;
    [SerializeField] private Volume volume;

    [Header("Motion Blur")]
    [SerializeField] private bool useMotionBlur = true;
    [SerializeField] private float minMotionBlur = 0f;
    [SerializeField] private float maxMotionBlur = 0.7f;

    [Header("Depth Of Field (optional)")]
    [SerializeField] private bool useDepthOfField;
    [SerializeField] private float minDoFBlur = 0f;
    [SerializeField] private float maxDoFBlur = 1f;

    private MotionBlur motionBlur;
    private DepthOfField depthOfField;

    private void Awake()
    {
        if (drunkBar == null)
            drunkBar = FindFirstObjectByType<DrunkBar>();

        if (volume == null)
            volume = FindFirstObjectByType<Volume>();

        if (volume == null || volume.profile == null)
        {
            Debug.LogWarning("DrunkBlurController: Missing Volume or Volume Profile.");
            enabled = false;
            return;
        }

        if (useMotionBlur)
            volume.profile.TryGet(out motionBlur);

        if (useDepthOfField)
            volume.profile.TryGet(out depthOfField);

        if (useMotionBlur && motionBlur == null)
            Debug.LogWarning("DrunkBlurController: MotionBlur override not found in Volume Profile.");

        if (useDepthOfField && depthOfField == null)
            Debug.LogWarning("DrunkBlurController: DepthOfField override not found in Volume Profile.");
    }

    private void Update()
    {
        if (drunkBar == null)
            return;

        float t = 0f;
        if (drunkBar.drunkMaxAmount > 0f)
            t = Mathf.Clamp01(drunkBar.drunkAmount / drunkBar.drunkMaxAmount);

        if (useMotionBlur && motionBlur != null)
        {
            motionBlur.active = true;
            motionBlur.intensity.overrideState = true;
            motionBlur.intensity.value = Mathf.Lerp(minMotionBlur, maxMotionBlur, t);
        }

        if (useDepthOfField && depthOfField != null)
        {
            depthOfField.active = true;
            depthOfField.mode.overrideState = true;
            depthOfField.mode.value = DepthOfFieldMode.Gaussian;

            depthOfField.gaussianStart.overrideState = true;
            depthOfField.gaussianEnd.overrideState = true;
            depthOfField.gaussianMaxRadius.overrideState = true;

            // Pull the in-focus range closer and increase blur radius as drunkness rises.
            depthOfField.gaussianStart.value = 0.1f;
            depthOfField.gaussianEnd.value = Mathf.Lerp(60f, 2f, t);
            depthOfField.gaussianMaxRadius.value = Mathf.Lerp(minDoFBlur, maxDoFBlur, t);
        }
    }
}
