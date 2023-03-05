using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public JsonController _jsonController;
    public int currentLevel = 1;
    public GameObject[] puzzlePieces;
    public GameObject[] puzzlePieceTargetPositions;
    public Material[] materials1;
    public Material[] materials2;
    public int currentPuzzlePiece = 0;
    public GameObject character,characterWithAnim,smoke;
    public bool isPuzzleComplate = false;
    public bool isCharacterComplate = false;
    public float rotationSpeed = 0.1f;
    public float puzzleMoveSpeed = 0.8f;

    public void Awake() 
    {
        instance = this;
    }
    
    void Start()
    {
        _jsonController.JsonLoad();
        currentLevel = _jsonController.user1.level;
        // forwardSpeed = _jsonController.user1.forwardSpeed;
        // currentThrowDigit = _jsonController.user1.currentThrowDigit;
        // throwRate = _jsonController.user1.throwRate;
        // range = _jsonController.user1.range;
        // textScore.text = _jsonController.user1.totalScore.ToString();
        // currentThrowDigitValue = currentThrowDigit;
    }
    
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     for (int i = 0; i < puzzlePieces.Length; i++)
        //     {
        //         puzzlePieces[i].GetComponent<Renderer>().material = materials1[i];
        //     }
        // }
    }
    public void LevelEndSave()
    {
        _jsonController.user1.level = currentLevel;
        //_jsonController.user1.forwardSpeed = forwardSpeed;
        //_jsonController.user1.currentThrowDigit = currentThrowDigit;
        //_jsonController.user1.throwRate = throwRate;
        //_jsonController.user1.range = range;
        //_jsonController.user1.totalScore += gameScore;
        _jsonController.JsonSave();
    }
}
