using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 6;
    public Vector3 cameraVel;
    private PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (player.finish) return;
        if(player.canMove)
        transform.position += Vector3.forward * cameraSpeed ;
        cameraVel= Vector3.forward * cameraSpeed ;
    }
}
