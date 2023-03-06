using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Gate : MonoBehaviour
{
    [SerializeField] private GameObject givenObject;
    [SerializeField] private int legoNeedForObject;
    [SerializeField] private int legoDeposit;
    [SerializeField] private Image gateImage;
    [SerializeField] private Image gateImageBackground;

    [SerializeField] public bool isObjectOpen = false;
    [SerializeField] private Image ObjectUIImage;
    
    //[SerializeField] private GameObject gateWP;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            
            case  "CollectableLego"://Gate Image acilir, collectedItems daki son nesne way pointe tasinir
                legoDeposit++;
                if(legoDeposit >= legoNeedForObject+1)
                    break;
                
                gateImage.DOFillAmount(legoDeposit/(float)legoNeedForObject,0.3f);
                gateImageBackground.DOFillAmount(1-legoDeposit/(float)legoNeedForObject,0.3f);

                //UI Açılan Parça Resmi Güncelleme
                ObjectUIImage.DOFillAmount(legoDeposit/(float)legoNeedForObject,0.3f);
                
                GameObject currentObj = PlayerCollect.playerCollectScript.collectedItems[PlayerCollect.playerCollectScript.collectedItems.Count-1];
                currentObj.GetComponent<SmoothDamp>().enabled = false;
                currentObj.tag = "Untagged";
                
                PlayerCollect.playerCollectScript.collectedItems.Remove(
                   PlayerCollect.playerCollectScript.collectedItems[^1]);
//                PlayerCollect.playerCollectScript.waypoint.transform.position -= new Vector3(0, 0f, 1f);
                Destroy(currentObj.gameObject);
                
                if (legoDeposit == legoNeedForObject)
                {
                    // isObjectOpen = true;
                }
                break;
        }
    }
}
