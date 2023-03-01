using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoAnimation : MonoBehaviour
{
    void Update()
    {
        rotateTrap();
    }
    private void rotateTrap()
    {
        transform.Rotate(new Vector3(0f,0f,1f));
    }
}
