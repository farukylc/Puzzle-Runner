using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    public float jumpForce = 3;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "WallLine":

                anim.SetBool("isJumping", true);
                transform.DOJump(transform.position + new Vector3(0, 0, 10f), 2.5f, 1, 1, false).SetEase(Ease.Linear);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "WallLine":
                anim.SetBool("isJumping",false);
                break;
        }   
    }
}
