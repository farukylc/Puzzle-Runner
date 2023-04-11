using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2RunnerController : MonoBehaviour
{
    public GameObject[] character1Pieces;
    public GameObject[] character2Pieces;
    public GameObject[] character3Pieces;
    public Material[] materials;
    void Start()
    {
        if(GameManager.instance.isCharacter2Change)
        {
            for(int i = 0; i < character1Pieces.Length; i++)
            {
                
                character1Pieces[i].GetComponent<Renderer>().material = materials[i];
                character2Pieces[i].GetComponent<Renderer>().material = materials[i];
                character3Pieces[i].GetComponent<Renderer>().material = materials[i];
            }
            ChangeMaterial(character1Pieces[3], 1, 5);
            ChangeMaterial(character1Pieces[4], 1, 0);
            ChangeMaterial(character1Pieces[5], 1, 3);
            ChangeMaterial(character2Pieces[3], 1, 3);
            ChangeMaterial(character2Pieces[3], 2, 5);
            ChangeMaterial(character2Pieces[4], 1, 0);
            ChangeMaterial(character2Pieces[5], 1, 3);
            ChangeMaterial(character3Pieces[3], 1, 3);
            ChangeMaterial(character3Pieces[3], 2, 5);
            ChangeMaterial(character3Pieces[4], 1, 0);
            ChangeMaterial(character3Pieces[5], 1, 3);
        }
    }

    void Update()
    {
        
    }
    void ChangeMaterial(GameObject obj, int materialIndex ,int setMaterialIndex)//degisecek obje, objenin hangi materiali degisecek, hangi material ile degistirilecek
    {
        var characterMaterials = obj.GetComponent<Renderer>().materials;
        characterMaterials[materialIndex] = materials[setMaterialIndex];
        obj.GetComponent<Renderer>().materials = characterMaterials;
    }
}
