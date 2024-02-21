using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 6;
    public Vector3 cameraVel;

    void Update()
    {
        transform.position += Vector3.forward * cameraSpeed * Time.deltaTime;
        cameraVel= Vector3.forward * cameraSpeed * Time.deltaTime;
    }
}
