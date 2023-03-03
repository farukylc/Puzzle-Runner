using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ObjectBuilder : MonoBehaviour
{
    public static ObjectBuilder objectBuilderScript;
    [SerializeField] private List<GameObject> objectPieces = new List<GameObject>();
    [SerializeField] private List<GameObject> targetPositionObject = new List<GameObject>();
    [SerializeField] public GameObject winPanel;
    [SerializeField] private GameObject scoreBar;
    [SerializeField] private TextMeshProUGUI goldAmountText;
    

    private void Start()
    {
        objectBuilderScript = this;
    }
    // PlayerCollect.playerCollectScript.collectedLegos >= PlayerCollect.playerCollectScript.targetScore
    private void buildFunction()
    {
        if (PlayerCollect.playerCollectScript.isObjectOpen)
        {
            var sequence = DOTween.Sequence();
            int pieceIndex = 0;
            foreach (var objectPiece in objectPieces)
            {
                
                sequence.Append(objectPiece.transform.DOMove(targetPositionObject[pieceIndex].transform.position,
                    0.25f)).OnComplete((() =>
                        
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
                Debug.Log("Köpek Alana Girdi");
                // InvokeRepeating("finalStack",0.1f,0.01f);
                scoreBar.transform.DOLocalMoveY(scoreBar.transform.localPosition.y + 400f,2);
                
                break;
            
            case "Cat":
                buildFunction();
                Debug.Log("Kedi Alan Girdi");
                scoreBar.transform.DOLocalMoveY(scoreBar.transform.localPosition.y + 400f,2);
               
                break;
        }
    }

    IEnumerator delay()
    {
        goldAmountText.text = PlayerCollect.playerCollectScript.goldAmount.ToString();
        yield return new WaitForSeconds(1.5f);
        winPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        UIAnimations.UIAnimationsScript.goldAnimation();
        
        
    }

    // [SerializeField] private GameObject finalWP;
    // private int i = 0;
    // private void finalStack()
    // {
    //     if (i < PlayerCollect.playerCollectScript.collectedItems.Count)
    //     {
    //         PlayerCollect.playerCollectScript.collectedItems[i].transform.DOLocalJump(finalWP.transform.localPosition, 4f, 1, 0.01f).OnComplete((
    //             () =>
    //             {
    //                 PlayerCollect.playerCollectScript.collectedItems[i].transform.SetParent(transform.gameObject.transform);
    //                 PlayerCollect.playerCollectScript.collectedItems[i].transform.localScale = PlayerCollect.playerCollectScript.collectedItems[i].transform.localScale / 1.25f;
    //                 PlayerCollect.playerCollectScript.collectedItems[i].transform.localRotation = Quaternion.Euler(0,90,0);
    //                 finalWP.transform.position += new Vector3(0, 0.44f, 0);
    //                 i++;
    //             }
    //         ));
    //         
    //         
    //     }
    // }
    
}
