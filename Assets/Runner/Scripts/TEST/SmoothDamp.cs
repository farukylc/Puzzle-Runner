using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDamp : MonoBehaviour
{
    public Transform currentleadTransform;
    private float currentVel = 0.0f;
    private float smoothTime = 0.1f;
    public bool isOn = true;

    
    void Update()
    {
        if (currentleadTransform==null)
        {
            return;
        }
        else
        {
            transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, currentleadTransform.position.x, ref currentVel, smoothTime), transform.position.y, transform.position.z);
        }     
      
    }
    public void SetLeadTransform(Transform leadTransform)
    {
        currentleadTransform = leadTransform;
    }
}
