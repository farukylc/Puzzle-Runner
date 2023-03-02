using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTrap : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Cat":
                anim.SetBool("isCatOnArea",true);
                break;
        }
    }
}
