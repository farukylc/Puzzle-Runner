using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] puzzlePieces;
    public GameObject[] puzzlePieceTargetPositions;
    public Material[] materials1;
    public Material[] materials2;
    public int currentPuzzlePiece = 0;
    public GameObject dog,dogWithAnim,smoke;
    public bool isPuzzleComplate = false;
    public float rotationSpeed = 0.1f;

    public void Awake() 
    {
        instance = this;
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < puzzlePieces.Length; i++)
            {
                puzzlePieces[i].GetComponent<Renderer>().material = materials1[i];
            }
        }
    }
}
