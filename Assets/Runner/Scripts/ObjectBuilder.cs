using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectBuilder : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectPieces = new List<GameObject>();
    [SerializeField] private List<GameObject> targetPositionObject = new List<GameObject>();
    //[SerializeField] private GameObject particle;
    //[SerializeField] private GameObject newParent;
    [SerializeField] private GameObject winPanel;

    private void buildFunction()
    {


        if (PlayerCollect.playerCollectScript.collectedLegos >= PlayerCollect.playerCollectScript.targetScore)
        {
            var sequence = DOTween.Sequence();
            int pieceIndex = 0;
            foreach (var objectPiece in objectPieces)
            {
                //objectPiece.transform.SetParent(newParent.transform);
                sequence.Append(objectPiece.transform.DOMove(targetPositionObject[pieceIndex].transform.position,
                    0.25f)).OnComplete((() => 
                        //newParent.transform.DOMove(new Vector3(newParent.transform.position.x,newParent.transform.position.y+10f,newParent.transform.position.z + 10f),2)
                        winPanel.SetActive(true)
                    ));
            
                pieceIndex++;
            }
        }

        else
        {
            Debug.Log("You Lose");
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                buildFunction();
                Debug.Log(":(");
                break;
        }
    }
}
