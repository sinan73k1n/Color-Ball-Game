using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftAndRight : MonoBehaviour
{

    public float distance, speed;
    private float minX, maxX;

    public bool right, dontMove;
    private bool stop;
    private GameManager gm;
    private void Awake()
    {
        gm = FindAnyObjectByType<GameManager>();
    }
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        maxX = transform.position.x + distance;
        minX = transform.position.x - distance;
    }

    void Update()
    {
        if (!stop && !dontMove)
        {
            if (right)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                if (transform.position.x > maxX)
                    right = false;
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                if (transform.position.x <= minX)
                    right = true;
            }
        }
    }

    private void OnCollisionEnter(Collision target)
    {
        DestroyableObject temp = target.gameObject.GetComponent<DestroyableObject>();
        if (target.gameObject.tag == "White"&&target.gameObject.GetComponent<Rigidbody>().velocity.magnitude>1 ||
            target.gameObject.name=="Player"||temp!=null && target.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1)
        {
            stop = true;
            GetComponent<Rigidbody>().freezeRotation = false;
        }
    }
}
