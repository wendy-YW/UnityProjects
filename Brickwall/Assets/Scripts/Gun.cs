using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject BallSpawnPoint;
    [SerializeField] GameObject RedBall;
    [SerializeField] GameObject BlueBall;
    [SerializeField] GameObject GreenBall;

    private void Update()
    {
        if(Time.timeScale != 0)
        {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left-click.");
            Instantiate(RedBall, BallSpawnPoint.transform.position, BallSpawnPoint.transform.rotation);        
        
        }
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed right-click.");
            Instantiate(GreenBall, BallSpawnPoint.transform.position, BallSpawnPoint.transform.rotation);        
        
        }
        if(Input.GetMouseButtonDown(2))
        {
            Debug.Log("Pressed middle-click.");
            Instantiate(BlueBall, BallSpawnPoint.transform.position, BallSpawnPoint.transform.rotation);
        }
        }else
        {
            Debug.Log("Time is stopped");
        }
    }
}
