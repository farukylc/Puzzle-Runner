using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TouchController : MonoBehaviour
{
    public GameObject tapToBuild,
                      firstPuzzlePiece,
                      firstPuzzleContent;
    public ScrollRect scroll;
    public bool isStart;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log($"{(float)firstPuzzleContent.transform.GetSiblingIndex()/scroll.content.transform.childCount}");
            isStart = true; 
            tapToBuild.SetActive(false);
            gameObject.SetActive(false);
            scroll.DOHorizontalNormalizedPos(1,3f).OnComplete(()=>
                scroll.DOHorizontalNormalizedPos((float)firstPuzzleContent.transform.GetSiblingIndex()/scroll.content.transform.childCount,1f).OnComplete(()=>
                    firstPuzzlePiece.GetComponent<Animator>().enabled = true));
        }
    }
}
