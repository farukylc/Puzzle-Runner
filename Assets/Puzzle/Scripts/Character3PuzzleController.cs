using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character3PuzzleController : MonoBehaviour
{
    public GameObject[] puzzlePieces;
    public GameObject[] characterPieces;
    public Material[] materials1;
    void Start()
    {
        if(GameManager.instance.currentLevel%11==0)
            {
                for(int i = 0; i < puzzlePieces.Length; i++)
                {
                    puzzlePieces[i].GetComponent<Renderer>().material = materials1[i];
                    characterPieces[i].GetComponent<Renderer>().material = materials1[i];
                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
