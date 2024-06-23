using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{   
    [SerializeField] float Force = 50f;
    Rigidbody rb;
   void Start(){
        rb=GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*Force,ForceMode.Impulse);
        
   }
}
