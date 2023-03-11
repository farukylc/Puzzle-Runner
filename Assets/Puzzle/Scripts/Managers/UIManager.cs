using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    GameManager _gameManager;
    SceneControlManager _sceneManager;
    public GameObject nextPreviousButtons,characterObjects;
    public Image runButtonImage;
    public Button runButton; 
    public void Awake() 
    {
        instance = this;
    }
    void Start()
    {
        _gameManager = GameManager.instance; 
        _sceneManager = SceneControlManager.instance;
        if(_gameManager.isCharacterComplate)
        {
            nextPreviousButtons.SetActive(true);
            characterObjects.SetActive(true);
        }   
    }

    void Update()
    {
        
    }
    public void OnClickSet1()
    {
        for (int i = 0; i < _gameManager.puzzlePieces.Length; i++)
            {
                _gameManager.puzzlePieces[i].GetComponent<Renderer>().material = _gameManager.materials1[i];
            }
    }
    public void ButtonRun()
    {
        _gameManager.characterWithAnim.GetComponent<CharacterController>().CharacterRotate();
    }
    public void ButtonNextPuzzle()
    {
        _sceneManager.NextPuzzleLevel();
    }
    public void ButtonPreviousPuzzle()
    {
        _sceneManager.PreviousPuzzleLevel();
    }
    public void FillAmount()
    {
        runButtonImage.DOFillAmount((_gameManager.currentPuzzlePiece+1)/(float)_gameManager.puzzlePieces.Length,_gameManager.puzzleMoveSpeed);
    }
    public void ActivetedButton()
    {
        runButton.interactable = true;
    }
}
