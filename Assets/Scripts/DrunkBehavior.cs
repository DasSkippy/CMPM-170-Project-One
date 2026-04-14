using UnityEngine;
using System.Collections;

public class DrunkBehavior : MonoBehaviour
{
    public Animator eyesAnimator;
    public float minBlinkTime;
    public float maxBlinkTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Blink(Random.Range(minBlinkTime, maxBlinkTime)));
    }

    private IEnumerator Blink(float time)
    {
        yield return new WaitForSeconds(time);
        eyesAnimator.SetTrigger("blink");
        StartCoroutine(Blink(Random.Range(minBlinkTime, maxBlinkTime)));
    }
}
