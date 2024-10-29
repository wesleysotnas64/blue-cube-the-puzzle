using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int form;
    public GameObject cube;
    
    void Start()
    {
        if (form == 1) InitForm1();
        else if (form == 2) InitForm2();
    }

    public void LeftPlatform()
    {
        if(form == 1)
        {
            StartCoroutine(GetComponent<PlatformPresentation>().PresentationOutCoroutine());
        }
        else if (form == 2)
        {   
            form--;
            cube.GetComponent<MeshRenderer>().material.color = Color.HSVToRGB(0, 0, 1);
        }
    }

    public void InitForm1()
    {
        cube.GetComponent<MeshRenderer>().material.color = Color.HSVToRGB(0, 0, 1);
    }

    public void InitForm2()
    {
        cube.GetComponent<MeshRenderer>().material.color = Color.HSVToRGB(0, 0.75f, 1);
    }
}
