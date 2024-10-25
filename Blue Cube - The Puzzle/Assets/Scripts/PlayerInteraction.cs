using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject.transform.parent.transform.gameObject);
    }
}
