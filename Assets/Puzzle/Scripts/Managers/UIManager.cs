using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    GameManager _gameManager;
    SceneControlManager _sceneManager;
    void Start()
    {
        _gameManager = GameManager.instance; 
        _sceneManager = SceneControlManager.instance;
    }

    // Update is called once per frame
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
        // for (int i = 0; i < _gameManager.puzzlePieces.Length; i++)
        //     {
        //         _gameManager.puzzlePieces[i].GetComponent<Renderer>().material = _gameManager.materials2[i];
        //     }
    }
    public void ButtonNextPuzzle()
    {
        _sceneManager.NextPuzzleLevel();
    }
    public void ButtonPreviousPuzzle()
    {
        _sceneManager.PreviousPuzzleLevel();
    }
}
