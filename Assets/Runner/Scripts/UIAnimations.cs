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
            tapToPlay.transform
                .DORotate(
                    new Vector3(transform.localRotation.x, transform.localRotation.y, transform.localPosition.z + 44f),
                    2).OnComplete((() => 
                        tapToPlay.transform
                            .DORotate(
                                new Vector3(transform.localRotation.x, transform.localRotation.y, transform.localPosition.z - 90f),
                                2)
                    ));
            //tapToPlay.transform.d
        }
    }
    private int currentImageIndex = 0;
    public void goldAnimation()
    {
        
        // for (int i = 0; i < goldImageList.Count; i++)
        // {
        //     goldImageList[i].transform.DOMove(goldIconTarget.transform.position, 2);
        // }

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
