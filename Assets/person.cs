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
        if (PlayerPrefs.GetInt("IntValue") == 1)
        {
            transform.position = new Vector3(-120f, -507f, -371f);

        }
        else if(PlayerPrefs.GetInt("IntValue") == 2)
        {
            transform.position = new Vector3(172f, -506f, -374f);
            GameObject go = GameObject.Find("Main Camera");
            go.transform.position = new Vector3(189f, -389f, -392f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + (Vector3.right * moveSpeed);
        //transform.Translate(Input.acceleration.x * moveSpeed, 0, -Input.acceleration.z * moveSpeed);
        

    }
}
