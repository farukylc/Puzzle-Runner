using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Trap : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                Debug.Log("Collision detected");
                other.transform.DOMove(new Vector3(other.transform.position.x, other.transform.position.y,
                    other.transform.position.z - 10f), 0.5f);
                break;
            
        }
    }
}
