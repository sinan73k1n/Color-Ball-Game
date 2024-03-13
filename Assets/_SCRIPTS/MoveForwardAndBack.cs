using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardAndBack : MonoBehaviour
{

    public float distance, speed;
    private float minZ, maxZ;

    public bool forward, dontMove;
    private bool stop;
 
    void Start()
    {
        maxZ = transform.position.z + distance;
        minZ = transform.position.z - distance;
    }

    void Update()
    {
        if (!stop && !dontMove)
        {
            if (forward)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
                if (transform.position.z > maxZ)
                    forward = false;
            }
            else
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
                if (transform.position.z <= minZ)
                    forward = true;
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
