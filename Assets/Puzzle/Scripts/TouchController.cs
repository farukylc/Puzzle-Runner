using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public GameObject tapToBuild,
                      firstPuzzlePiece;
    public bool isStart;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isStart = true; 
            tapToBuild.SetActive(false);
            gameObject.SetActive(false);
            firstPuzzlePiece.GetComponent<Animator>().enabled = true;
        }
    }
}
