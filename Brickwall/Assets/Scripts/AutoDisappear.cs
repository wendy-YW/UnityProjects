using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisappear : MonoBehaviour
{
    public float thresholdY = -5.0f;

    void Update()
    {
        if (transform.position.y < thresholdY)
        {
            // Option 1: Deactivate the object (can be reactivated later)
            // gameObject.SetActive(false);

            // Option 2: Destroy the object (cannot be recovered)
            Destroy(gameObject);
        }
    }
}
