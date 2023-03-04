using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private GameObject givenObject;
    [SerializeField] private int legoNeedForObject;
    [SerializeField] private int legoDeposit;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":

                if (legoDeposit == legoNeedForObject)
                {
                    
                    Debug.Log("Obje Verildi");
                    
                }
                
                break;
            
            
            case  "CollectableLego":

                legoDeposit++;
                Destroy(other.gameObject);
                 PlayerCollect.playerCollectScript.collectedItems.Remove(
                   PlayerCollect.playerCollectScript.collectedItems[^1]);
                
                PlayerCollect.playerCollectScript.waypoint.transform.position -= new Vector3(0, 0f, 1f);
                
                break;
        }
    }
}
