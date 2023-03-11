using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class LegoColor : MonoBehaviour
{
    [SerializeField] private List<Material> materials = new List<Material>();
    [SerializeField] private List<GameObject> legosOnScene = new List<GameObject>();
    [SerializeField] private List<GameObject> scoreWall = new List<GameObject>();
    [SerializeField] private List<Material> scoreWallColor = new List<Material>();
    [SerializeField] private List<TextMeshPro> scoreText = new List<TextMeshPro>();
    private float wallFloat = 1.0f;
    void Start()
    {
        for (int i = 0; i < legosOnScene.Count; i++)
        {
            legosOnScene[i].gameObject.GetComponent<MeshRenderer>().material =
                materials[Random.Range(0, materials.Count)];
        }


        for (int i = 0; i < scoreWall.Count; i++)
        {
            scoreWall[i].gameObject.GetComponent<MeshRenderer>().material.color =
                scoreWallColor[Random.Range(0, scoreWallColor.Count)].color;

        }
    }
}
