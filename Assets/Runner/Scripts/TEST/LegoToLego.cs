using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoToLego : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case  "CollectableLego":
                PlayerCollect.playerCollectScript.collectedItems.Add(other.gameObject);
                other.gameObject.transform.position = PlayerCollect.playerCollectScript.waypoint.transform.position;
                break;
        }
    }
}
