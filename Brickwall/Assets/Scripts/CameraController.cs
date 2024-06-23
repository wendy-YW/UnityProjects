using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 6.0f;
    // Start is called before the first frame update
    
    void Start()
    {
        Debug.Log("CameraController script started");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            this.transform.position += transform.up * this.moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            this.transform.position -= transform.up * this.moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) {
            this.transform.position -= transform.right * this.moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            this.transform.position += transform.right * this.moveSpeed * Time.deltaTime;
        }
    }
}


