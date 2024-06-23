using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
       // Start is called before the first frame update
    public float accelerationForce = 2000f;
    public float steeringForce = 1200f;
    public float reverseForce = 1000f;
    public GameObject blue_car;
    private Rigidbody rigid_body;
    public float timedelta = 1.0f;
    // public float x = 0.0f;
    public GameObject wp1;
    void Start()
    {
        Debug.Log("Car Starting");
        rigid_body = blue_car.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        //rigid_body.position = Vector3.MoveTowards(rigid_body.position, wp1.transform.position, 0.1f);
        var heading = wp1.transform.position - blue_car.transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        // Debug.Log(direction);

        // if(Input.GetKey(KeyCode.W))
        // {   
        //     Debug.Log("Car Moving Forward");
        //      rigid_body.AddForce(blue_car.transform.forward * accelerationForce);
        //    // GetComponent<Rigidbody>().AddForce(transform.forward * accelerationForce);
        // }
        // if(Input.GetKey(KeyCode.S))
        // {
        //     rigid_body.AddForce(blue_car.transform.forward * -1 * reverseForce);
        //     //GetComponent<Rigidbody>().AddForce(transform.forward * -reverseForce);
        // }
        // if(Input.GetKey(KeyCode.A))
        // {
        //     rigid_body.AddTorque(blue_car.transform.up * -steeringForce);
        //     Debug.Log("Car Moving Left");
        //     //GetComponent<Rigidbody>().AddTorque(transform.up * -steeringForce);
        // }
        // if(Input.GetKey(KeyCode.D))
        // {   
        //     rigid_body.AddTorque(blue_car.transform.up * steeringForce);
        //     //GetComponent<Rigidbody>().AddTorque(transform.up * steeringForce);
        // }
    }

    void Drive(){
        rigid_body.AddForce(blue_car.transform.forward * accelerationForce);
    }

    void Turn(int turn = 0){
        // if == 0 => dont turn
        // if turn == 1 => turn left
        // if turn == -1 => turn right
        rigid_body.AddTorque(blue_car.transform.up * steeringForce * turn);
    }
}