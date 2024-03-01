using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneEngine : MonoBehaviour
{
    [SerializeField] GameObject parentClone;
    [SerializeField] GameObject[] cloneObjs;
    float countTime = 0;
    private void Update()
    {
        countTime += Time.deltaTime;
        if (countTime < 0.5) return;
        countTime = 0;

        GameObject clone = Instantiate(cloneObjs[Random.Range(0, cloneObjs.Length)]);
        clone.transform.SetParent(parentClone.transform);
        Vector3 temp = transform.position;
        temp.x = Random.Range(-4.5f, 4.5f);
        clone.transform.position = temp;
        
    }

}
