using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    GameManager _gameManager;
    void Start()
    {
        _gameManager = GameManager.instance; 
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
    public void OnClickSet2()
    {
        _gameManager.dogWithAnim.GetComponent<DogController>().DogRotate();
        // for (int i = 0; i < _gameManager.puzzlePieces.Length; i++)
        //     {
        //         _gameManager.puzzlePieces[i].GetComponent<Renderer>().material = _gameManager.materials2[i];
        //     }
    }
}
