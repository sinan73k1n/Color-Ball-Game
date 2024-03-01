using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControllerIntro : MonoBehaviour
{

    private Rigidbody myRb;
    private Vector3 lastTouchPos;
    public float sensitivity = .16f, clampDelta = 43f;
    public float bounds = 5;
    bool started = false;

    Vector3 randomLoc = new Vector3();
    float timeForNextMove = 3f,countForNextMove=0;
    void Awake()
    {
        myRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RandomLocation();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds, bounds), transform.position.y, transform.position.z);
        if (started)
            transform.position += FindObjectOfType<CameraMovementIntro>().cameraVel;

    }
    void FixedUpdate()
    {
        
        if (!started)
        {
            started = true;
            randomLoc = Input.mousePosition;
            lastTouchPos = randomLoc;

        }

        if (started)
        {

                Vector3 vector = lastTouchPos - randomLoc;

                lastTouchPos = randomLoc;
                vector = new Vector3(vector.x, 0, vector.y);

                Vector3 moveForce = Vector3.ClampMagnitude(vector, clampDelta);
                myRb.AddForce(-moveForce * sensitivity - myRb.velocity / 5f, ForceMode.VelocityChange);

        }

        myRb.velocity.Normalize();
    }

    void RandomLocation()
    {
        countForNextMove += Time.deltaTime;
        if (countForNextMove < timeForNextMove) return;
        countForNextMove = 0;
        timeForNextMove = Random.Range(1, 3);
        randomLoc.x = Random.Range(0, 90001);
        randomLoc.y = Random.Range(0, 18000);
        randomLoc.z = 0;

    }
    

}
