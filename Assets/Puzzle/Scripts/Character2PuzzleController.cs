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
                Material [] characterMaterials = characterPieces[4].GetComponent<Renderer>().materials;
                characterMaterials[1] = materials1[4];
                characterMaterials[2] = materials1[8];
                characterPieces[4].GetComponent<Renderer>().materials = characterMaterials;
                characterMaterials = null;
                characterMaterials = characterPieces[8].GetComponent<Renderer>().materials;
                characterMaterials[1] = materials1[4];
                characterPieces[8].GetComponent<Renderer>().materials = characterMaterials;
                characterMaterials = null;
                characterMaterials = characterPieces[7].GetComponent<Renderer>().materials;
                characterMaterials[1] = materials1[0];
                characterPieces[7].GetComponent<Renderer>().materials = characterMaterials;
                characterMaterials = null;
                characterMaterials = puzzlePieces[7].GetComponent<Renderer>().materials;
                characterMaterials[1] = materials1[0];
                puzzlePieces[7].GetComponent<Renderer>().materials = characterMaterials;
                characterMaterials = null;
                characterMaterials = puzzlePieces[8].GetComponent<Renderer>().materials;
                characterMaterials[1] = materials1[4];
                puzzlePieces[8].GetComponent<Renderer>().materials = characterMaterials;
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
