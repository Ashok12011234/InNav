using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class person : MonoBehaviour
{
    public float moveSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hii");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + (Vector3.right * moveSpeed);
        transform.Translate(Input.acceleration.x * moveSpeed, 0, -Input.acceleration.z * moveSpeed);
        Debug.Log(Input.acceleration);

    }
}
