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
        if(GameManager.instance.isCharacter3Change)
        {
            for(int i = 0; i < 4; i++)
            {
                puzzlePieces[i].GetComponent<Renderer>().material = materials1[i];
                characterPieces[i].GetComponent<Renderer>().material = materials1[i];
            }
            ChangeMaterial(puzzlePieces[4], 1, 4);
            ChangeMaterial(characterPieces[4], 1, 4);
            if(!GameManager.instance.isHead)
                puzzlePieces[3].GetComponent<Renderer>().material = GameManager.instance.transparentMaterial;
            if(!GameManager.instance.isBackFoot)
                puzzlePieces[0].GetComponent<Renderer>().material = GameManager.instance.transparentMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeMaterial(GameObject obj, int materialIndex ,int setMaterialIndex)
    {
        var characterMaterials = obj.GetComponent<Renderer>().materials;
        characterMaterials[materialIndex] = materials1[setMaterialIndex];
        obj.GetComponent<Renderer>().materials = characterMaterials;
    }
}
