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

        if (tag == "Platform_Final")
        {
            playerMove.ShrinkScaleY();
        }
        else if (tag == "Platform_Fall")
        {
            playerMove.Fall();
        }
        else if(tag == "Platform_Teleport")
        {
            playerMove.TeleportTo(other.gameObject.GetComponent<Platform>().toTeleportPlatform);
        }
    }
}
