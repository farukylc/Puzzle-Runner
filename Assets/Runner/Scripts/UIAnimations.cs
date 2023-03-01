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
    private void Start()
    {
       InvokeRepeating("doPunchUI",1,0.5f);
       UIAnimationsScript = this;
    }
    
    private void doPunchUI()
    {
        uıDoubleImage.transform.DOPunchScale(Vector3.one * 0.25f, 0.49f, 1, 1f);
    }

    public void goldAnimation()
    {
        for (int i = 0; i < goldImageList.Count; i++)
        {
            goldImageList[i].transform.DOMove(goldIconTarget.transform.position, 2);
            delay();
        }
    }

    private IEnumerator delay()
    {
        yield return new WaitForSeconds(2);
    }


}
