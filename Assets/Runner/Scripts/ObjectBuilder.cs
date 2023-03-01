using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ObjectBuilder : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectPieces = new List<GameObject>();
    [SerializeField] private List<GameObject> targetPositionObject = new List<GameObject>();
    //[SerializeField] private GameObject particle;
    //[SerializeField] private GameObject newParent;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject scoreBar;

    [SerializeField] private TextMeshProUGUI goldAmountText;
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
                        StartCoroutine("delay")
                        

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
                Debug.Log("Alana girildi");
                scoreBar.transform.DOLocalMoveY(scoreBar.transform.localPosition.y + 200f,2);
                break;
        }
    }

    IEnumerator delay()
    {
        goldAmountText.text = PlayerCollect.playerCollectScript.bonusScore.ToString();
        yield return new WaitForSeconds(1.5f);
        winPanel.SetActive(true);
    }
}
