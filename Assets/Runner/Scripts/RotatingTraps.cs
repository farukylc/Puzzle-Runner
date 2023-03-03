using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class RotatingTraps : MonoBehaviour
{
    [SerializeField] private bool swing = false;
    [SerializeField] private bool mace = false;

    private void Start()
    {
        InvokeRepeating("rotateFunc",1,7);
    }

    void Update()
    {
        
        RotateFunc();
        
    }

    private void RotateFunc()
    {
        if (swing)
        {
            swing = false;

            transform.DOLocalRotate(new Vector3(45f, 0, 0), 0.85f).OnComplete((() =>
            {
                transform.DOLocalRotate(new Vector3(-45f, 0, 0), 0.85f).OnComplete((() =>
                    swing = true));
            }));

        }

        if (mace)
        {
            mace = false;
            transform.DOLocalRotate(new Vector3(0f, 0, 45f), 0.85f).OnComplete((() =>
                    {
                        transform.DOLocalRotate(new Vector3(0f, 0, -45f), 0.85f).OnComplete((() =>
                            mace = true));

                    }
                 ));
            
            
            
        }
    }
    
}
