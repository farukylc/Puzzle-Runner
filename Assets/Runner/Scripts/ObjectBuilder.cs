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

    private void buildFunction()
    {
        if (PlayerCollect.playerCollectScript.collectedLegos >= PlayerCollect.playerCollectScript.targetScore)
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
                scoreBar.transform.DOLocalMoveY(scoreBar.transform.localPosition.y + 200f,2);
                break;
            
            case "Cat":
                buildFunction();
                Debug.Log("Kedi Alan Girdi");
                scoreBar.transform.DOLocalMoveY(scoreBar.transform.localPosition.y + 200f,2);
                break;
        }
    }

    IEnumerator delay()
    {
        goldAmountText.text = PlayerCollect.playerCollectScript.bonusScore.ToString();
        yield return new WaitForSeconds(1.5f);
        winPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        UIAnimations.UIAnimationsScript.goldAnimation();
        
        
    }
}
