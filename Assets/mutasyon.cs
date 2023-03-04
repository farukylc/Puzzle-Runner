using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mutasyon : MonoBehaviour
{
    [SerializeField] private GameObject bacak;
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        
        {
                case "Player":
                    bacak.gameObject.SetActive(true);
                    break;
        }
    }
}
