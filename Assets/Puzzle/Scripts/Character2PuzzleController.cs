using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2PuzzleController : MonoBehaviour
{
   public GameObject[] puzzlePieces;
    public GameObject[] characterPieces;
    public Material[] materials1;
    void Start()
    {
        if(GameManager.instance.isCharacter2Change)
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
