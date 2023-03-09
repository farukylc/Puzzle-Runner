using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ObjectBuilder : MonoBehaviour
{
    public static ObjectBuilder objectBuilderScript;
    [SerializeField] private List<GameObject> objectPieces = new List<GameObject>();
    [SerializeField] private List<GameObject> targetPositionObject = new List<GameObject>();
    [SerializeField] public GameObject winPanel;
    [SerializeField] private GameObject objectiveBar;
    [SerializeField] private TextMeshProUGUI goldAmountText;
    [SerializeField] private CinemachineVirtualCamera cam1;
    [SerializeField] private GameObject movementPanel;
    [SerializeField] private GameObject tower, towerWP;
    
    private void Start()
    {
        objectBuilderScript = this;
    }
    // PlayerCollect.playerCollectScript.collectedLegos >= PlayerCollect.playerCollectScript.targetScore
    private void buildFunction()
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
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                movementPanel.SetActive(false);
                transform.DOMove(new Vector3(0, transform.position.y, transform.position.z), 2);
                
                Debug.Log("Köpek Alana Girdi");
                objectiveBar.transform.DOLocalMoveY(objectiveBar.transform.localPosition.y + 410f,5);
                cam1.gameObject.SetActive(false);
                
                other.gameObject.transform.DOMove(towerWP.transform.position, 2f).OnComplete((() =>
                {
                    
                    other.transform.SetParent(tower.transform);
                    cam1.enabled = false;
                    tower.transform.DOLocalMoveY(50f, 4f).OnComplete((() =>
                        buildFunction()));
                }
                    ));
                
            break;
            
            case "Cat":
                buildFunction();
                Debug.Log("Kedi Alan Girdi");
                objectiveBar.transform.DOLocalMoveY(objectiveBar.transform.localPosition.y + 400f,2);
                
                
            break;
            
            case "CollectableLego":
                Destroy(other.gameObject);
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
}
