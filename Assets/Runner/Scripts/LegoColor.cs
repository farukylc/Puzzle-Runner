using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class LegoColor : MonoBehaviour
{
    [SerializeField] private List<Material> materials = new List<Material>();
    [SerializeField] private List<GameObject> legosOnScene = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < legosOnScene.Count; i++)
        {
            legosOnScene[i].gameObject.GetComponent<MeshRenderer>().material =
                materials[Random.Range(0, materials.Count)];
        }
    }
    
}