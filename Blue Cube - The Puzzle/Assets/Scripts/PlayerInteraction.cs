using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        string tag = other.gameObject.tag;
        if (tag == "Platform")
        {
            other.transform.parent.GetComponent<Platform>().LeftPlatform();
        }
    }
}
