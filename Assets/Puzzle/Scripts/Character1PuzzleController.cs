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
    {
        if(GameManager.instance.isCharacter1Change)
        {
            for(int i = 0; i < puzzlePieces.Length; i++)
            {
                puzzlePieces[i].GetComponent<Renderer>().material = materials1[i];
                characterPieces[i].GetComponent<Renderer>().material = materials1[i];
            }
        }
        if(GameManager.instance.currentLevel == 1)
            panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
