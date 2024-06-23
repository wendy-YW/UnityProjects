using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject PivotPoint_GO;
    public GameObject TextField_GO;
    public float FoV = 60.0f;
    public float min_FoV = 15.0f;
    public float max_FoV = 90.0f;
    public float rate_FoV = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            this.RotateCamera(true);
         }
        if(Input.GetKey(KeyCode.LeftArrow)){
            this.RotateCamera(false);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            if(this.min_FoV<this.FoV){
                this.FoV-=this.rate_FoV;
            }
            Camera.main.fieldOfView=this.FoV;
            // this.ZoomCamera(true);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            if(this.max_FoV>this.FoV){
                this.FoV+=this.rate_FoV;
            }
            Camera.main.fieldOfView=this.FoV;
            // this.ZoomCamera(true);
        }

        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit,100f)){
                // Debug.Log(hit.transform.name);
                if(hit.transform.name != null){
                    Debug.Log(hit.transform.gameObject.name);
                    TextMeshProUGUI text_field = this.TextField_GO.GetComponent<TextMeshProUGUI>();
                    text_field.text = "Shape" + hit.transform.gameObject.name;
                    // Debug.Log("Cube");
                    // hit.transform.GetComponent<CubeController>().ChangeColor();
                }
            }
        }


    }

    public void RotateCamera(bool right)
    {
       float speed = 0.2f;
       Vector3 pivotPoint=PivotPoint_GO.transform.position;
       if(right){
           this.transform.RotateAround(pivotPoint,Vector3.up,-speed);
         }else{
            this.transform.RotateAround(pivotPoint,Vector3.up,speed);
        }
    }
}
