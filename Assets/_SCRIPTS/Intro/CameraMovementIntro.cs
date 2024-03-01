using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementIntro : MonoBehaviour
{
    public float cameraSpeed = 6;
    public Vector3 cameraVel;
    public GameObject graound;
    float countGraound = 1;
    private void Awake()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.forward * cameraSpeed ;
        cameraVel= Vector3.forward * cameraSpeed ;
        CloneGraound();

    }

    void CloneGraound()
    {
        float temp = transform.position.z;
        if (temp / 160 > countGraound)
        {
            countGraound++;
            GameObject clone = Instantiate(graound, transform.position, Quaternion.identity);
            Vector3 tempv = clone.transform.position;
            tempv.z= 160 * countGraound;
            clone.transform.position = tempv;
        }
    }
}
