using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy"|| other.tag == "White")
        {
            Destroy(other.gameObject);
        }
    }
}
