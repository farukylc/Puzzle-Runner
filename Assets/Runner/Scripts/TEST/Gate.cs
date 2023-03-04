using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gate : MonoBehaviour
{
    [SerializeField] private GameObject givenObject;
    [SerializeField] private int legoNeedForObject;
    [SerializeField] private int legoDeposit;
    [SerializeField] private Image gateImage;
    [SerializeField] private Image gateImageBackground;

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
                if(legoDeposit >= legoNeedForObject)
                    break;
                gateImage.fillAmount += legoDeposit/(float)legoNeedForObject;
                gateImageBackground.fillAmount -= legoDeposit/(float)legoNeedForObject;
                GameObject currentObj = PlayerCollect.playerCollectScript.collectedItems[PlayerCollect.playerCollectScript.collectedItems.Count-1];
                currentObj.GetComponent<SmoothDamp>().enabled = false;
                currentObj.transform.position = gateWP.transform.position;
                currentObj.transform.SetParent(transform);
                gateWP.transform.position += new Vector3(0, 0.5f, 0);
                PlayerCollect.playerCollectScript.collectedItems.Remove(
                   PlayerCollect.playerCollectScript.collectedItems[^1]);
                PlayerCollect.playerCollectScript.waypoint.transform.position -= new Vector3(0, 0f, 1f);
                
            break;
        }
    }
}
