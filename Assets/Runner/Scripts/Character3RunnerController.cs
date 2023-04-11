using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character3RunnerController : MonoBehaviour
{
    public GameObject[] character1Pieces;
    public GameObject[] character2Pieces;
    public GameObject[] character3Pieces;
    public Material[] materials;
    void Start()
    {
        if(GameManager.instance.isCharacter3Change)
        {
            for(int i = 0; i < 4; i++)
            {
                
                character1Pieces[i].GetComponent<Renderer>().material = materials[i];
                character2Pieces[i].GetComponent<Renderer>().material = materials[i];
                character3Pieces[i].GetComponent<Renderer>().material = materials[i];
            }
            ChangeMaterial(character1Pieces[4], 1, 4);
            ChangeMaterial(character2Pieces[4], 1, 4);
            ChangeMaterial(character3Pieces[4], 1, 4);
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
