using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPresentation : MonoBehaviour
{
    public float duration;
    private Vector3 initialPosition;
    private Vector3 finalPosition;

    public void Init()
    {
        finalPosition = transform.position;
        initialPosition = transform.position + new Vector3(0, -5, 0);

        transform.position = initialPosition;
        transform.localScale = Vector3.zero;

        duration = 0.5f;

        StartCoroutine(PresentationInCoroutine());
    }

    public IEnumerator PresentationInCoroutine()
    {

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(initialPosition, finalPosition, elapsedTime / duration);
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            // elapsedTime = elapsedTime >= 1 ? 1 : elapsedTime;
            yield return null;
        }

        transform.position = finalPosition;
        transform.localScale = Vector3.one;
    }

    public IEnumerator PresentationOutCoroutine()
    {

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(finalPosition, initialPosition, elapsedTime / duration);
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = initialPosition;
        transform.localScale = Vector3.zero;
    }
}
