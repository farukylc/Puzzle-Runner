using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PuzzleControl : MonoBehaviour
{
    GameManager _gameManager;
    UIManager _uIManager;
    GameObject targetPoint;
    float xScale, yScale, zScale;
    //public float speed = 1f;
    bool isMoving = false,
         isTimerOpen = false;
    public int puzzlePieceIndex;
    GameObject currentPiece;
    float clickTime = 0f;
    void Start ()
    {
        _gameManager = GameManager.instance; 
        _uIManager = UIManager.instance;
    }
    void Update ()
    {
        if(clickTime+3f<Time.time & isTimerOpen & !isMoving)
        {
            isTimerOpen = false;
            TouchController.instance.ScrollMove(_gameManager.puzzlePieces[_gameManager.currentPuzzlePiece]);
        }
    }

    public void buttonClick()
    {
        if(isMoving || _gameManager.currentPuzzlePiece != puzzlePieceIndex) return;//hareket bitene kadar butonlar calismaz
        isMoving = true;
        isTimerOpen = true;
        clickTime = Time.time;
        Debug.Log(clickTime);
        targetPoint = _gameManager.puzzlePieceTargetPositions[_gameManager.currentPuzzlePiece];//siradaki puzzle parcasinin gidecegi konum
        xScale =targetPoint.transform.localScale.x;
        yScale =targetPoint.transform.localScale.y;
        zScale =targetPoint.transform.localScale.z;

        currentPiece = _gameManager.puzzlePieces[_gameManager.currentPuzzlePiece];//siradaki puzzle parcasi
        //currentPiece.GetComponent<Animator>().enabled = false;
        Destroy(currentPiece.GetComponent<Animator>());
        currentPiece.layer = 0;
        currentPiece.transform.SetParent(_gameManager.character.transform);

        _uIManager.FillAmount();

        currentPiece.transform.DOMove(targetPoint.transform.position,_gameManager.puzzleMoveSpeed);
        currentPiece.transform.DORotateQuaternion(targetPoint.transform.rotation,_gameManager.puzzleMoveSpeed);
        currentPiece.transform.DOScale(new Vector3(xScale,yScale,zScale)*2, _gameManager.puzzleMoveSpeed).OnComplete((() =>
        {
            targetPoint.SetActive(false);
            if(_gameManager.currentPuzzlePiece==_gameManager.puzzlePieces.Length-1)//son puzzle parcasi yerine gitti ise
            {
                _gameManager.isPuzzleComplate = true;
                _gameManager.character.SetActive(false);
                _gameManager.characterWithAnim.SetActive(true);
                _uIManager.ActivetedButton();
            }
            _gameManager.currentPuzzlePiece++;
            _gameManager.puzzlePieceTargetPositions[_gameManager.currentPuzzlePiece].SetActive(true);
            //_gameManager.puzzlePieces[_gameManager.currentPuzzlePiece].GetComponent<Animator>().enabled = true;
                        
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
