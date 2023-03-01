using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAnimations : MonoBehaviour
{
    [SerializeField] private Transform uıDoubleImage;


    private void Start()
    {
       InvokeRepeating("doPunchUI",1,0.5f);
    }
    
    private void doPunchUI()
    {
        
        uıDoubleImage.transform.DOPunchScale(Vector3.one * 0.25f, 0.49f, 1, 1f);
        
    }
   
}
