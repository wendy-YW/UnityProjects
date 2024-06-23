using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class NPC_Controller : MonoBehaviour
{
   
    [SerializeField] WheelCollider [] wheelColliders;
//    [SerializeField] WheelCollider frontLeftWheelCollider;
//     [SerializeField] WheelCollider frontRightWheelCollider;
//     [SerializeField] WheelCollider rearLeftWheelCollider;
//     [SerializeField] WheelCollider rearRightWheelCollider;
    [SerializeField] Transform [] wheelMeshes;
    public float force_acceleration = 1000f;
    public float force_brake = 600f;   
    public float maxTurnAngle = 15f;

    private float current_acceleration = 0f;
    private float current_brake = 0f;
    private float currentTurnAngle = 0f;

    public GameObject waypoints;
    private List<GameObject>wps=new();
    private int next_wp_index=0;
    private float towards_direction = 0.0f;
    private int laps = 0;
     private void OnTriggerEnter(Collider other){
        Debug.Log($"Bot car collided with {other.gameObject.name}");
        if(other.gameObject.name==this.wps[next_wp_index].name){
            ChangeNextWP();
        }
    }

    void Start(){
        foreach(Transform child in this.waypoints.transform){
            this.wps.Add(child.gameObject);
        }
    }

void FixedUpdate(){

    this.CollectUserInputs();
    //Accerelation forward / reverse (keys W / S)
//     this.current_acceleration = this.force_acceleration * Input.GetAxis("Vertical");
//     // Brake
//    if (Input.GetKey(KeyCode.Space)){
//        this.current_brake = this.force_brake;
//    } else {
//        this.current_brake = 0f;
//    }
    //Apply accleration to front wheels
    this.Accelerate();
    //Apply brake to all wheels
    this.Brake();

    // take care of the steering
    this.Turn();

    // update the wheel meshes
    UpdateWheel(wheelColliders[0], wheelMeshes[0]);
    UpdateWheel(wheelColliders[1], wheelMeshes[1]);
    UpdateWheel(wheelColliders[2], wheelMeshes[2]);
    UpdateWheel(wheelColliders[3], wheelMeshes[3]);


}

void Accelerate(){
        this.wheelColliders[0].motorTorque = this.current_acceleration;
    this.wheelColliders[1].motorTorque = this.current_acceleration;
}
void Brake(){
    this.wheelColliders[0].brakeTorque = this.current_brake;
    this.wheelColliders[1].brakeTorque = this.current_brake;
    this.wheelColliders[2].brakeTorque = this.current_brake;
    this.wheelColliders[3].brakeTorque = this.current_brake;
}

void Turn(){
    this.currentTurnAngle = this.maxTurnAngle * Input.GetAxis("Horizontal");
    this.wheelColliders[0].steerAngle = this.currentTurnAngle;
    this.wheelColliders[1].steerAngle = this.currentTurnAngle;
}

void CollectUserInputs(){
    //Accerelation forward / reverse (keys W / S)
    this.current_acceleration = this.force_acceleration * 1;
    // bot doesnt brake
    // get direction of next waypoint
    
    this.towards_direction = GetDirection(this.gameObject, this.wps[this.next_wp_index].gameObject);
    float turn = this.towards_direction;
    if (turn > this.maxTurnAngle){
        turn = this.maxTurnAngle;
    }
    this.currentTurnAngle = turn;//TODO
}

float GetDirection(GameObject sourceObject, GameObject targetGameObject){

    Vector3 direction = (targetGameObject.transform.position - sourceObject.transform.position).normalized;
    float degrees = Vector3.Angle(sourceObject.transform.forward, direction); // this will return degrees from 0 to 180
    Vector3 cross = Vector3.Cross(sourceObject.transform.forward, direction); // y-axia is either positive or negative
    if(cross.y < 0) degrees = -degrees;
    return degrees;  // degrees is bw -180 and 180
}

void UpdateWheel(WheelCollider col, Transform trans){

    //get wheel collider state
    Vector3 position;
    Quaternion rotation;
    col.GetWorldPose(out position, out rotation);

    trans.position = position;
    trans.rotation = rotation;

}

void ChangeNextWP(){
    int last_wp_index = this.next_wp_index;
    if(this.next_wp_index==this.wps.Count-1){
        this.next_wp_index=0;
        this.laps++;
    }else{
        this.next_wp_index++;
    }
    this.UpdateStatus(last_wp_index);

}

void UpdateStatus(int prev_index = -1){
    //TODO
    if(prev_index==-1){
        Debug.Log($"Player car passed waypoint {this.next_wp_index}");
    }else{
        Debug.Log($"Player car passed waypoint {prev_index} and is now on waypoint {this.next_wp_index}");
    }
}

}
