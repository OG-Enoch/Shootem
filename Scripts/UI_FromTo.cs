using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FromTo : MonoBehaviour
{
    public Vector2 targetPosition;
    float lerpDuration = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Lerp());
        StartCoroutine(LerpPosition(targetPosition, 0.2f));
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.position = Vector2.Lerp(transform.position, target.transform.position, time);
        time += Time.deltaTime;*/
    }
    IEnumerator Lerp()
    {
        float timeElapsed = 0;
        while(timeElapsed < lerpDuration)
        {
            transform.localScale = new Vector2(Mathf.Lerp(0.5f, 0.3f, timeElapsed / lerpDuration), Mathf.Lerp(0.5f, 0.3f, timeElapsed / lerpDuration));
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        transform.localScale = new Vector2(0.3f, 0.3f);
    }
    IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0.0f;
        Vector2 startPosition = transform.position;

        while(time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;

            yield return null;
        }
        transform.position = targetPosition;
    }
}
