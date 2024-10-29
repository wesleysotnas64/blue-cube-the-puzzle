using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum PivoDirection
{
    Forward = 0, // Índice 0 corresponde a 'forward'
    Back = 1,    // Índice 1 corresponde a 'back'
    Left = 2,    // Índice 2 corresponde a 'left'
    Right = 3    // Índice 3 corresponde a 'right'
}

public enum ScaleAnim
{
    Grow = 0,   //Crescer
    Shrink = 1  //Encolher
}

public class PlayerMove : MonoBehaviour
{
    public GameObject player;
    public GameObject cube;
    public List<GameObject> pivoList; //[0] foward | [1] back | [2] left | [3] right 

    public bool rotating;
    public bool scaleYAnimation;
    public bool colapsed;
    public float duration;
    public Vector3 targetRotation;
    public Vector3 displacement;

    void Start()
    {
        rotating = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && rotating == false && colapsed == false && scaleYAnimation == false) MoveFoward();
        if(Input.GetKeyDown(KeyCode.D) && rotating == false && colapsed == false && scaleYAnimation == false) MoveBack();
        if(Input.GetKeyDown(KeyCode.E) && rotating == false && colapsed == false && scaleYAnimation == false) MoveLeft();
        if(Input.GetKeyDown(KeyCode.F) && rotating == false && colapsed == false && scaleYAnimation == false) MoveRight();

        //Teste de escala
        if(Input.GetKeyDown(KeyCode.U) && scaleYAnimation == false) GrowScaleY();
        if(Input.GetKeyDown(KeyCode.J) && scaleYAnimation == false) ShrinkScaleY();
    }

    public void GrowScaleY()
    {
        StartCoroutine(ScaleYAnimatioCoroutine(ScaleAnim.Grow));
    }

    public void ShrinkScaleY()
    {
        StartCoroutine(ScaleYAnimatioCoroutine(ScaleAnim.Shrink));
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

    private IEnumerator ScaleYAnimatioCoroutine(ScaleAnim anim)
    {
        yield return new WaitForSeconds(0.05f);
        scaleYAnimation = true;

        Vector3 initialScale = Vector3.zero;
        Vector3 finalScale = Vector3.zero;

        if(anim == ScaleAnim.Grow)
        {
            initialScale = new Vector3(1, 0, 1);
            finalScale = new Vector3(1, 1, 1);
            colapsed = false;
        }
        else if(anim == ScaleAnim.Shrink)
        {
            initialScale = new Vector3(1, 1, 1);
            finalScale = new Vector3(1, 0, 1);
            colapsed = true;
        }


        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = finalScale;

        scaleYAnimation = false;
    }
}
