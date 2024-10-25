using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cubeTransform;
    public float speed;

    void Start()
    {
        cubeTransform = GameObject.Find("Player").transform;
        cubeTransform = cubeTransform.Find("Cube").transform;
    }

    void Update()
    {
        if (cubeTransform != null)
        {
            transform.position = Vector3.Lerp(transform.position, cubeTransform.position, Time.deltaTime*speed);
        }
    }
}
