using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Trap : MonoBehaviour
{
    //[SerializeField] private GameObject smoke;
   
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                //
                Debug.Log("Collision detected");
                other.transform.DOMove(new Vector3(other.transform.position.x, other.transform.position.y,
                    other.transform.position.z - 10f), 0.5f);

                scoreUpdate();

                break;
            
            case "Cat":
                
                Debug.Log("Collision detected");
                other.transform.DOMove(new Vector3(other.transform.position.x, other.transform.position.y,
                    other.transform.position.z - 10f), 0.5f);
                
                    scoreUpdate();
                break;
        }
    }

    private void scoreUpdate()
    {
       
       
        if (PlayerCollect.playerCollectScript.collectedItems.Count !=0)
        {
            PlayerCollect.playerCollectScript.collectedLegos--;
            PlayerCollect.playerCollectScript.scoreSlider.value = PlayerCollect.playerCollectScript.collectedLegos;
            //RustemDeneme
            GameObject currentObj = PlayerCollect.playerCollectScript.collectedItems[PlayerCollect.playerCollectScript.collectedItems.Count-1];
            int throwDistance = -6;
            if(PlayerCollect.playerCollectScript.collectedItems.Count%2==0)
                throwDistance = 6;
            currentObj.transform.DOLocalRotate(new Vector3(-180,90,-90),0.5f).SetEase(Ease.Linear);
            currentObj.transform.DOScale(currentObj.transform.localScale/2,0.5f).SetEase(Ease.Linear);
            currentObj.transform.DOLocalJump(new Vector3(currentObj.transform.localPosition.x+throwDistance,1,currentObj.transform.localPosition.z+1),4,1,0.5f).SetEase(Ease.Linear).OnComplete(()=>{

                Destroy(PlayerCollect.playerCollectScript.collectedItems[PlayerCollect.playerCollectScript.collectedItems.Count-1].gameObject); 
            PlayerCollect.playerCollectScript.collectedItems.Remove(
                PlayerCollect.playerCollectScript.collectedItems[
                    PlayerCollect.playerCollectScript.collectedItems.Count-1]);
            PlayerCollect.playerCollectScript .waypoint.transform.position -= new Vector3(0, 0.44f, 0);

            });
            //RustemDeneme
            // Destroy(PlayerCollect.playerCollectScript.collectedItems[PlayerCollect.playerCollectScript.collectedItems.Count-1].gameObject); 
            // PlayerCollect.playerCollectScript.collectedItems.Remove(
            //     PlayerCollect.playerCollectScript.collectedItems[
            //         PlayerCollect.playerCollectScript.collectedItems.Count-1]);
            // PlayerCollect.playerCollectScript .waypoint.transform.position -= new Vector3(0, 0.44f, 0);
        }
        
                
        
        
       
    }
}
