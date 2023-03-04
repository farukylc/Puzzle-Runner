using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private GameObject givenObject;
    [SerializeField] private int legoNeedForObject;
    [SerializeField] private int legoDeposit;


    [SerializeField] private GameObject gateWP;

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
                PlayerCollect.playerCollectScript.collectedItems[^1].transform.position = gateWP.transform.position;
                PlayerCollect.playerCollectScript.collectedItems[^1].gameObject.transform.SetParent(transform);
                gateWP.transform.position += new Vector3(0, 0.5f, 0);
                 PlayerCollect.playerCollectScript.collectedItems.Remove(
                   PlayerCollect.playerCollectScript.collectedItems[^1]);
                
                PlayerCollect.playerCollectScript.waypoint.transform.position -= new Vector3(0, 0f, 1f);

                other.gameObject.GetComponent<SmoothDamp>().enabled = false;
                
                break;
        }
    }
}
