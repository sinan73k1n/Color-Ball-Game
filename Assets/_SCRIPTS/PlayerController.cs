using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody myRb;
    private Vector3 lastTouchPos;
    public float sensitivity = .16f, clampDelta = 42f;
    public float bounds = 5;

    void Awake()
    {
        myRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds, bounds), transform.position.y,transform.position.z);
        transform.position += FindObjectOfType<CameraMovement>().cameraVel;
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            //lastTouchPos = Camera.main.ScreenToWorldPoint( Input.mousePosition);
            lastTouchPos = Input.mousePosition;
            Debug.Log(lastTouchPos);
        }

        if (Input.GetMouseButton(0))
        {
           

            Vector3 vector = lastTouchPos - Input.mousePosition;
            Debug.Log(vector);
            lastTouchPos = Input.mousePosition;
            vector = new Vector3(vector.x, 0, vector.y);

            Vector3 moveForce = Vector3.ClampMagnitude(vector, clampDelta);
            myRb.AddForce(-moveForce * sensitivity - myRb.velocity / 5f, ForceMode.VelocityChange);

        }
        myRb.velocity.Normalize();
    }
}
