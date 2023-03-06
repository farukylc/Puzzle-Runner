using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class VoidTrap : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                
                if (PlayerCollect.playerCollectScript.collectedItems.Count != 0)
                {
                    transform.gameObject.GetComponent<MeshRenderer>().material =
                        PlayerCollect.playerCollectScript.collectedItems[^1].transform.gameObject
                            .GetComponent<MeshRenderer>().material;
                    Destroy(PlayerCollect.playerCollectScript.collectedItems[PlayerCollect.playerCollectScript.collectedItems.Count-1].gameObject);
                    PlayerCollect.playerCollectScript.collectedItems.Remove(
                        PlayerCollect.playerCollectScript.collectedItems[^1]);
                
                    //PlayerCollect.playerCollectScript.waypoint.transform.position -= new Vector3(0, 0.44f, 0);
                
                    transform.gameObject.GetComponent<MeshRenderer>().enabled = true;

                }
                break;
        }
    }
    
}
