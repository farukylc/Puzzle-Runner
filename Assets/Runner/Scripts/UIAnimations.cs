using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIAnimations : MonoBehaviour
{
    [SerializeField] private Transform uıDoubleImage;
    [SerializeField] private Image goldImage;
    [SerializeField] private GameObject Canvas;
    private void Start()
    {
       InvokeRepeating("doPunchUI",1,0.5f);
    }
    
    private void doPunchUI()
    {
        uıDoubleImage.transform.DOPunchScale(Vector3.one * 0.25f, 0.49f, 1, 1f);
    }

    private void goldImageSpawner()
    {   
        Instantiate(goldImage.transform.gameObject, Canvas.transform);
    }
}
