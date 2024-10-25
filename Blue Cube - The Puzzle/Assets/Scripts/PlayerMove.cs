using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PivoDirection
{
    Forward = 0, // Índice 0 corresponde a 'forward'
    Back = 1,    // Índice 1 corresponde a 'back'
    Left = 2,    // Índice 2 corresponde a 'left'
    Right = 3    // Índice 3 corresponde a 'right'
}

public class PlayerMove : MonoBehaviour
{
    public GameObject player;
    public GameObject cube;
    public List<GameObject> pivoList; //[0] foward | [1] back | [2] left | [3] right 

    public bool rotating;
    public float duration;
    public Vector3 targetRotation;
    public Vector3 displacement;

    void Start()
    {
        rotating = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && rotating == false) MoveFoward();
        if(Input.GetKeyDown(KeyCode.D) && rotating == false) MoveBack();
        if(Input.GetKeyDown(KeyCode.E) && rotating == false) MoveLeft();
        if(Input.GetKeyDown(KeyCode.F) && rotating == false) MoveRight();
    }

    private void MoveFoward()
    {
        targetRotation = new Vector3(0,0,-90);
        displacement = new Vector3(1,0,0);
        StartCoroutine(RotateCoroutine(PivoDirection.Forward));
    }

    private void MoveBack()
    {
        targetRotation = new Vector3(0,0,90);
        displacement = new Vector3(-1,0,0);
        StartCoroutine(RotateCoroutine(PivoDirection.Back));
    }

    private void MoveLeft()
    {
        targetRotation = new Vector3(90,0,0);
        displacement = new Vector3(0,0,1);
        StartCoroutine(RotateCoroutine(PivoDirection.Left));
    }

    private void MoveRight()
    {
        targetRotation = new Vector3(-90,0,0);
        displacement = new Vector3(0,0,-1);
        StartCoroutine(RotateCoroutine(PivoDirection.Right));
    }

    private IEnumerator RotateCoroutine(PivoDirection _pivoDirection)
    {
        rotating =  true;
        Vector3 cubeInitialPosition = cube.transform.position;
        cube.transform.parent = pivoList[(int)_pivoDirection].transform;

        Quaternion initialRotation = pivoList[(int)_pivoDirection].transform.rotation;
        Quaternion finalRotation = Quaternion.Euler(targetRotation);

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            pivoList[(int)_pivoDirection].transform.rotation = Quaternion.Lerp(initialRotation, finalRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        pivoList[(int)_pivoDirection].transform.rotation = finalRotation;

        cube.transform.parent = player.transform;
        cube.transform.position = cubeInitialPosition + displacement;
        pivoList[(int)_pivoDirection].transform.rotation = Quaternion.Euler(0,0,0);

        foreach(GameObject pivo in pivoList)
        {
            pivo.transform.position += displacement;
        }

        rotating = false;
    }
}
