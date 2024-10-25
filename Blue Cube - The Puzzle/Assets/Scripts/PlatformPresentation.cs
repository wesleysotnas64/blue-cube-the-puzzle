using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPresentation : MonoBehaviour
{
    public float duration;
    private Vector3 initialPosition;
    private Vector3 finalPosition;
    void Start()
    {
        finalPosition = new Vector3(transform.position.x, 0, transform.position.z);
        initialPosition = transform.position;

        duration = Random.Range(2.0f, 3.0f);

        StartCoroutine(PresentationInCoroutine());
    }

    private IEnumerator PresentationInCoroutine()
    {

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(transform.position, finalPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = finalPosition;
    }
}
