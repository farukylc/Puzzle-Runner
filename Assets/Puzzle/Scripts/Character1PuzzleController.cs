using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1PuzzleController : MonoBehaviour
{
    public GameObject[] puzzlePieces;
    public GameObject[] characterPieces;
    public Material[] materials1;
    public GameObject panel;
    void Start()
    {Debug.Log("material");
        if(GameManager.instance.isCharacter1Change)
        {
            for(int i = 0; i < puzzlePieces.Length; i++)
            {
                
                puzzlePieces[i].GetComponent<Renderer>().material = materials1[i];
                characterPieces[i].GetComponent<Renderer>().material = materials1[i];
            }
            puzzlePieces[6].GetComponent<Renderer>().materials[1] = materials1[5];
            characterPieces[6].GetComponent<Renderer>().materials[1] = materials1[5];
        }
        if(GameManager.instance.currentLevel == 1)
            panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
