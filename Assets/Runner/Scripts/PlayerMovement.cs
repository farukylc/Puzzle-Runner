using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
// using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private bool isStart = false;
    private Animator anim;
    [SerializeField] public int speed = 15;
    //[SerializeField] private CinemachineVirtualCamera mainCamera;
    [SerializeField] private GameObject tapToPlay;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.instance.isBackFoot = false;
            GameManager.instance.isHead = false;
            isStart = true; 
            tapToPlay.SetActive(false);
            anim.SetBool("isStarted",true);
        }
        
        if (isStart == true)
        {
            gameObject.transform.parent.transform.Translate(0,0,speed*Time.deltaTime);
        }
        
        PlayerClamp();
       
    }
    private void PlayerClamp()
    {
        var pos = transform.position; 
        pos.x =  Mathf.Clamp(transform.position.x, -4.45f, 4.45f);
        transform.position = pos;
    
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Finish":
                speed = 0;
                anim.SetBool("isStarted", false);
                //mainCamera.transform.gameObject.SetActive(false);
                break;
        }
    }
}


