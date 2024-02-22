using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody myRb;
    private Vector3 lastTouchPos;
    public float sensitivity = .16f, clampDelta = 43f;
    public float bounds = 5;

    [HideInInspector]
    public bool canMove, gameOver, finish;
    void Awake()
    {
        myRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds, bounds), transform.position.y, transform.position.z);
        if (canMove)
            transform.position += FindObjectOfType<CameraMovement>().cameraVel;



        if (!canMove && gameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else if (!canMove && !finish)
        {
            if (Input.GetMouseButtonDown(0))
                canMove = true;
        }
    }
    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {

            lastTouchPos = Input.mousePosition;

        }

        if (canMove)
        {
            if (Input.GetMouseButton(0))
            {

                Vector3 vector = lastTouchPos - Input.mousePosition;
                lastTouchPos = Input.mousePosition;
                vector = new Vector3(vector.x, 0, vector.y);

                Vector3 moveForce = Vector3.ClampMagnitude(vector, clampDelta);
                myRb.AddForce(-moveForce * sensitivity - myRb.velocity / 5f, ForceMode.VelocityChange);

            }
        }

        myRb.velocity.Normalize();
    }
    void GameOver()
    {
        canMove = false;
        gameOver = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }


    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            GameOver();
        }
    }

    IEnumerator NextLevel()
    {

        finish = true;
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);
        yield return new WaitForSeconds(1);
       
        canMove = false;
        SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("Level"));
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.name == "Finish")
        {
            StartCoroutine(NextLevel());
        }
    }

}