using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public JsonController _jsonController;
    public bool isPuzzle = true;
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
    public GameObject backFoot,head,backFootWithAnim,headWithAnim;
    public bool isBackFoot = true,
                isHead = true;
    public Material transparentMaterial;
    public void Awake() 
    {
        instance = this;
    }
    
    void Start()
    {
        _jsonController.JsonLoad();
        currentLevel = _jsonController.user1.level;//en son oynanan level
        isBackFoot = _jsonController.user1.isFootOpen;
        isHead = _jsonController.user1.isHeadOpen;
        if(isPuzzle)
        {
            if(!isBackFoot) EmptyObject(backFoot,backFootWithAnim);// arka ayak toplanamadi ise
            if(!isHead) EmptyObject(head,headWithAnim);// kafa toplanamadi ise
        }
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
    public void EmptyObject(GameObject obj,GameObject obj2)//nesneyi animasyonlu karakterde kapatir, scroll daki nesnenin material lari transparan yapar
    {
        obj2.SetActive(false);
        Material []materials = obj.GetComponent<Renderer>().sharedMaterials;
        Material []newMaterials = new Material[materials.Length];
        for (int i = 0; i < materials.Length; i++)
        {
            newMaterials[i] = transparentMaterial;
        }
        obj.GetComponent<Renderer>().sharedMaterials = newMaterials;
    }
    public void PuzzleLevelEndSave()
    {
        _jsonController.user1.level = currentLevel;
        //_jsonController.user1.forwardSpeed = forwardSpeed;
        //_jsonController.user1.currentThrowDigit = currentThrowDigit;
        //_jsonController.user1.throwRate = throwRate;
        //_jsonController.user1.range = range;
        //_jsonController.user1.totalScore += gameScore;
        _jsonController.JsonSave();
    }
    public void RunnerLevelEndSave()
    {
        _jsonController.user1.level = currentLevel;
        //_jsonController.user1.forwardSpeed = forwardSpeed;
        //_jsonController.user1.currentThrowDigit = currentThrowDigit;
        //_jsonController.user1.throwRate = throwRate;
        //_jsonController.user1.range = range;
        //_jsonController.user1.totalScore += gameScore;
        _jsonController.user1.isFootOpen = isBackFoot;
        _jsonController.user1.isHeadOpen = isHead;
        _jsonController.JsonSave();
    }
}
