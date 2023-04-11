using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1RunnerController : MonoBehaviour
{
    public GameObject[] character1Pieces;
    public GameObject[] character2Pieces;
    public GameObject[] character3Pieces;
    public Material[] materials;
    void Start()
    {
        if(GameManager.instance.isCharacter1Change)
        {
            for(int i = 0; i < character1Pieces.Length; i++)
            {
                
                character1Pieces[i].GetComponent<Renderer>().material = materials[i];
                character2Pieces[i].GetComponent<Renderer>().material = materials[i];
                character3Pieces[i].GetComponent<Renderer>().material = materials[i];
            }
            ChangeMaterial(character2Pieces[6], 1, 5);
            ChangeMaterial(character2Pieces[6], 0, 0);
            ChangeMaterial(character3Pieces[6], 1, 5);
            ChangeMaterial(character3Pieces[6], 0, 0);
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
