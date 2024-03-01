using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraoundIntro : MonoBehaviour
{
    GameObject cameraParent;

    private void Awake()
    {
        cameraParent = FindAnyObjectByType<CameraMovementIntro>().gameObject;
    }

    private void Update()
    {
        if (cameraParent.transform.position.z - transform.position.z > 130)
            Destroy(gameObject);
    }
}
