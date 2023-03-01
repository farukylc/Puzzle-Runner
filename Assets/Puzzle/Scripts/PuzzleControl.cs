using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PuzzleControl : MonoBehaviour
{
    GameManager _gameManager;
    GameObject targetPoint;
    float xScale, yScale, zScale;
    public float speed = 1f;
    bool isMoving = false;
    public int puzzlePieceIndex;
    GameObject currentPiece;

    void Start ()
    {
        _gameManager = GameManager.instance; 
    }
    void Update ()
    {

    }

    public void buttonClick()
    {
        if(isMoving || _gameManager.currentPuzzlePiece != puzzlePieceIndex) return;//hareket bitene kadar butonlar calismaz
        isMoving = true;
        targetPoint = _gameManager.puzzlePieceTargetPositions[_gameManager.currentPuzzlePiece];//siradaki puzzle parcasinin gidecegi konum
        xScale =targetPoint.transform.localScale.x;
        yScale =targetPoint.transform.localScale.y;
        zScale =targetPoint.transform.localScale.z;

        currentPiece = _gameManager.puzzlePieces[_gameManager.currentPuzzlePiece];//siradaki puzzle parcasi
        currentPiece.GetComponent<Animator>().enabled = false;
        currentPiece.layer = 0;
        currentPiece.transform.SetParent(_gameManager.dog.transform);

        currentPiece.transform.DOMove(targetPoint.transform.position,speed);
        currentPiece.transform.DORotateQuaternion(targetPoint.transform.rotation,speed);
        currentPiece.transform.DOScale(new Vector3(xScale,yScale,zScale)*3, speed).OnComplete((() =>
        {
            targetPoint.SetActive(false);
            if(_gameManager.currentPuzzlePiece==_gameManager.puzzlePieces.Length-1)//son puzzle parcasi yerine gitti ise
            {
                _gameManager.isPuzzleComplate = true;
                _gameManager.dog.gameObject.SetActive(false);
                _gameManager.dogWithAnim.gameObject.SetActive(true);
            }
            _gameManager.currentPuzzlePiece++;
            _gameManager.puzzlePieceTargetPositions[_gameManager.currentPuzzlePiece].SetActive(true);
            _gameManager.puzzlePieces[_gameManager.currentPuzzlePiece].GetComponent<Animator>().enabled = true;
                        
            isMoving = false;    
        }));
    }
    public void PunchScale()
    {
        if(isMoving) return;
        _gameManager.puzzlePieces[_gameManager.currentPuzzlePiece].transform.DOScale(_gameManager.puzzlePieces[_gameManager.currentPuzzlePiece].transform.localScale*1.20f,0.7f).OnComplete(()=>
            _gameManager.puzzlePieces[_gameManager.currentPuzzlePiece].transform.DOScale(/*_gameManager.puzzlePieces[_gameManager.currentPuzzlePiece].transform.localScale*/100,0.7f).OnComplete(()=> {
            if(!isMoving) 
                PunchScale();
        }));
    }
}
