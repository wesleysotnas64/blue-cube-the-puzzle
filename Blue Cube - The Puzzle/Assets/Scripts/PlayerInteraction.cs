using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public PlayerMove playerMove;
    void OnTriggerExit(Collider other)
    {
        string tag = other.gameObject.tag;
        if (tag == "Platform")
        {
            other.transform.parent.GetComponent<Platform>().LeftPlatform();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        Debug.Log("Chegou na plataforma final! "+ tag);
        if (tag == "Platform_Final")
        {
            playerMove.ShrinkScaleY();
        }
    }
}
