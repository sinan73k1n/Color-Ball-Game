using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DestroyableObject temp = other.gameObject.GetComponent<DestroyableObject>();
        if (temp!=null)
        {
            Destroy(other.gameObject);
        }
    }
}
