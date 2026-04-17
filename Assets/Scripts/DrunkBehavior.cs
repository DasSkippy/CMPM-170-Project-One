using UnityEngine;
using System.Collections;

public class DrunkBehavior : MonoBehaviour
{
    public Animator eyesAnimator;
    public float minBlinkTime = 10f;
    public float maxBlinkTime = 50f;
    public AudioClip BlinkAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Blink(Random.Range(minBlinkTime, maxBlinkTime)));
    }

    private IEnumerator Blink(float time)
    {
        yield return new WaitForSeconds(time);
        eyesAnimator.SetTrigger("blink");
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(BlinkAudio);
        StartCoroutine(Blink(Random.Range(minBlinkTime, maxBlinkTime)));
    }
}
