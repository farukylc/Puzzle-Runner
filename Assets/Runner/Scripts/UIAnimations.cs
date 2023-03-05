using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIAnimations : MonoBehaviour
{
    public static UIAnimations UIAnimationsScript;
    [SerializeField] private Transform uıDoubleImage;
    [SerializeField] private List<GameObject> goldImageList = new List<GameObject>();
    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject goldIconTarget;
    [SerializeField] private GameObject tapToPlayText;
    [SerializeField] private GameObject tapToPlay;
   
    private int i = 0;
    private void Start()
    {
       InvokeRepeating("doPunchUI",1,0.5f);
       UIAnimationsScript = this;
    }
    
    private void doPunchUI()
    {
        uıDoubleImage.transform.DOPunchScale(Vector3.one * 0.25f, 0.49f, 1, 1f);

        if (tapToPlay.activeSelf == true)
        {
            tapToPlayText.transform.DOPunchScale(Vector3.one * 0.25f, 0.49f, 1, 1f);
           
            //tapToPlay.transform.d
        }
    }
    private int currentImageIndex = 0;
    public void goldAnimation()
    {
        goldImageList[currentImageIndex].transform.DOMove(goldIconTarget.transform.position, 0.2f).OnComplete((() =>
                {
                    
                    currentImageIndex++;
                    if (currentImageIndex < goldImageList.Count)
                    {
                        goldAnimation();
                    }
                }
            ));
    }

   
}
