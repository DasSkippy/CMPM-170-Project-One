using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DrunkBlurController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DrunkBar drunkBar;
    [SerializeField] private Volume volume;

    [Header("Meter Mapping")]
    [SerializeField] private bool invertMeter;
    [SerializeField] private AnimationCurve responseCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    [Header("Motion Blur")]
    [SerializeField] private bool useMotionBlur = true;
    [SerializeField] private float minMotionBlur = 0f;
    [SerializeField] private float maxMotionBlur = 0.9f;
    [SerializeField] private bool forceHighQualityMotionBlur = true;

    [Header("Depth Of Field (optional)")]
    [SerializeField] private bool useDepthOfField;
    [SerializeField] private bool useSharedCurveForDepthOfField;
    [SerializeField] private float soberBokehFocusDistance = 0f;
    [SerializeField] private float soberBokehFocalLength = 1f;
    [SerializeField] private float soberBokehAperture = 16f;
    [SerializeField] private float maxBokehFocusDistance = 500f;
    [SerializeField] private float focusDistanceEasePower = 2.5f;
    [SerializeField] private float maxBokehFocalLength = 300f;
    [SerializeField] private float maxBokehAperture = 1f;

    [Header("Lens Distortion (optional)")]
    [SerializeField] private bool useLensDistortion = true;
    [SerializeField] private bool invertLensDistortionMeter = true;
    [SerializeField] private float soberLensDistortionIntensity = 0f;
    [SerializeField] private float maxLensDistortionIntensity = 0.75f;

    private MotionBlur motionBlur;
    private DepthOfField depthOfField;
    private LensDistortion lensDistortion;

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

        if (useLensDistortion)
            volume.profile.TryGet(out lensDistortion);

        if (useMotionBlur && motionBlur == null)
            Debug.LogWarning("DrunkBlurController: MotionBlur override not found in Volume Profile.");

        if (useDepthOfField && depthOfField == null)
            Debug.LogWarning("DrunkBlurController: DepthOfField override not found in Volume Profile.");

        if (useLensDistortion && lensDistortion == null)
            Debug.LogWarning("DrunkBlurController: LensDistortion override not found in Volume Profile.");

    }

    private void Update()
    {
        if (drunkBar == null)
            return;

        float rawT = 0f;
        if (drunkBar.drunkMaxAmount > 0f)
            rawT = Mathf.Clamp01(drunkBar.drunkAmount / drunkBar.drunkMaxAmount);

        float t = rawT;

        if (invertMeter)
            t = 1f - t;

        t = Mathf.Clamp01(responseCurve.Evaluate(t));

        if (useMotionBlur && motionBlur != null)
        {
            motionBlur.active = true;
            if (forceHighQualityMotionBlur)
            {
                motionBlur.quality.overrideState = true;
                motionBlur.quality.value = MotionBlurQuality.High;
            }
            motionBlur.intensity.overrideState = true;
            motionBlur.intensity.value = Mathf.Lerp(minMotionBlur, maxMotionBlur, t);
        }

        if (useDepthOfField && depthOfField != null)
        {
            float dofSourceT = 1f - rawT;
            float dofT = useSharedCurveForDepthOfField
                ? Mathf.Clamp01(responseCurve.Evaluate(dofSourceT))
                : dofSourceT;
            float focusMax = maxBokehFocusDistance > 1f ? maxBokehFocusDistance : 500f;
            float easedFocusT = Mathf.Pow(dofSourceT, Mathf.Max(1f, focusDistanceEasePower));

            depthOfField.active = true;
            depthOfField.mode.overrideState = true;
            depthOfField.mode.value = DepthOfFieldMode.Bokeh;

            depthOfField.focusDistance.overrideState = true;
            depthOfField.focalLength.overrideState = true;
            depthOfField.aperture.overrideState = true;

            // Force focus to start at 0 when fully drunk, then increase as the player sobers up.
            depthOfField.focusDistance.value = Mathf.Lerp(0f, focusMax, easedFocusT);
            depthOfField.focalLength.value = Mathf.Lerp(soberBokehFocalLength, maxBokehFocalLength, dofT);
            depthOfField.aperture.value = Mathf.Lerp(soberBokehAperture, maxBokehAperture, dofT);
        }

        if (useLensDistortion && lensDistortion != null)
        {
            float lensSourceT = invertLensDistortionMeter ? 1f - rawT : rawT;
            float lensT = Mathf.Clamp01(responseCurve.Evaluate(lensSourceT));
            lensDistortion.active = true;
            lensDistortion.intensity.overrideState = true;
            lensDistortion.intensity.value = Mathf.Lerp(soberLensDistortionIntensity, maxLensDistortionIntensity, lensT);
        }
    }
}
