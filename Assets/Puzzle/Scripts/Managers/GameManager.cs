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
    public Material transparentMaterial;
    [Header("---------------")]
    [Header("----Runner-----")]
    public GameObject characterWithNormal;
    public GameObject characterWithoutHead;
    public GameObject characterWithoutLeg;
    public bool isBackFoot = true,
                isHead = true;

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
            // if(currentLevel>5)
            // {
            //     for(int i = 0; i < puzzlePieces.Length; i++)
            //     {
            //         puzzlePieces[i].GetComponent<Renderer>().material = materials1[i];
            //     }
            // }
        }
        else if(!isPuzzle)
        {
            if(!isBackFoot) ChangeCharacter(characterWithoutLeg);// arka ayak toplanamadi ise
            else if(!isHead) ChangeCharacter(characterWithoutHead);// kafa toplanamadi ise
            else ChangeCharacter(characterWithNormal);
        }
        isBackFoot = false;
        isHead = false;
       
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
    public void ChangeCharacter(GameObject obj)//Puzzle da acilan karakteri runner sahnesinde aktif eder sag-sol kontrolu icin gecerli karakteri secer, sahnedeki collectable lari bulup aktif karakteri atar
    {
        Debug.Log("Change character calisti");
        characterWithNormal.SetActive(false);
        obj.SetActive(true);
        GameObject.FindWithTag("Cinemachine").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = obj.transform;
        RLMove.instance.playerTransform = obj.transform;
        GameObject[] collectables = GameObject.FindGameObjectsWithTag("CollectableLego");
        foreach (var item in collectables)
        {
            Debug.Log("collectable bulundu");
            item.GetComponent<SmoothDamp>().SetPlayer(obj);
        }
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
        Debug.Log("Kayit oldu");
        _jsonController.user1.level = currentLevel;
        //_jsonController.user1.forwardSpeed = forwardSpeed;
        //_jsonController.user1.currentThrowDigit = currentThrowDigit;
        //_jsonController.user1.throwRate = throwRate;
        //_jsonController.user1.range = range;
        //_jsonController.user1.totalScore += gameScore;
        if(!isBackFoot && !isHead)
        {
            if(Random.Range(0,2)%2==0) isHead = true;
            else isBackFoot = true;
        }
        _jsonController.user1.isFootOpen = isBackFoot;
        _jsonController.user1.isHeadOpen = isHead;
        _jsonController.JsonSave();
    }
}
