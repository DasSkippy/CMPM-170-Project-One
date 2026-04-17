using UnityEngine;

public class DrunkDriving : MonoBehaviour
{
    public DrunkBar drunkBar;

    public float minSwerveInterval;
    public float maxSwerveInterval;
    public float maxSwerveAngle;
    public float swerveSmoothness;

    private float targetSwerve;
    private float currentSwerve;
    private float swerveTimer;

    void Start()
    {
        if (drunkBar == null)
        {
            drunkBar = FindFirstObjectByType<DrunkBar>();
        }

        ResetSwerveTimer(1f);
    }

    void Update()
    {
        if (drunkBar == null) return;        

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow))
        {
            targetSwerve = 0f;
            currentSwerve = Mathf.Lerp(currentSwerve, 0f, Time.deltaTime * swerveSmoothness);
            return;
        }

        float soberPercent = drunkBar.drunkAmount / drunkBar.drunkMaxAmount;
        float drunkPercent = 1f - soberPercent;

        swerveTimer -= Time.deltaTime;

        if (swerveTimer <= 0f)
        {
            targetSwerve = Random.Range(-maxSwerveAngle, maxSwerveAngle) * drunkPercent;

            float nextInterval = Mathf.Lerp(maxSwerveInterval, minSwerveInterval, drunkPercent);
            ResetSwerveTimer(nextInterval);
        }

        currentSwerve = Mathf.Lerp(currentSwerve, targetSwerve, Time.deltaTime * swerveSmoothness);
        transform.Rotate(0f, currentSwerve * Time.deltaTime, 0f);
    }

    void ResetSwerveTimer(float timeAmount)
    {
        swerveTimer = timeAmount;
    }

    public float GetCurrentSwerve()
    {
        return currentSwerve;
    }
}