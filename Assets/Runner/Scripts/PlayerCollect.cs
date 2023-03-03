using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    public static PlayerCollect playerCollectScript;
    [SerializeField] public int collectedLegos = 0;
    [SerializeField] private GameObject legoIcon;
    private bool isPunch = false;
    private bool goldPunch = false;
    [SerializeField] public int bonusScore = 0;
    [SerializeField] public bool isObjectOpen = false;
     
    //UI
    [SerializeField] private GameObject smoke;
    [SerializeField] private int goldAmount = 0;
    [SerializeField] public Slider scoreSlider;
    [SerializeField] private TextMeshProUGUI goldAmountText;
    
   
    //[SerializeField] private int maxScore;
    [SerializeField] public int targetScore;
    [SerializeField] private Image goldIcon;
    [SerializeField] private Image qmImage;
    [SerializeField] private Sprite winObject;
    
    
    
    //Stack
    [SerializeField] public GameObject waypoint;
    [SerializeField] public List<GameObject> collectedItems = new List<GameObject>();
    
    
    
    
    private void Start()
    {
        scoreSlider.maxValue = targetScore;
       
        playerCollectScript = this;
        InvokeRepeating("qmAnimation",1,1);
    }
    
    private void Update()
    {
        if (targetScore <= collectedLegos)
        {
            CancelInvoke("qmAnimation");
            qmImage.sprite = winObject;
        }
           
    }

    private void qmAnimation()
    {
        if(collectedLegos < targetScore)
            qmImage.transform.DOPunchScale(Vector3.one * 0.5f, 0.5f, 1, 1f);
    }

    private void stackFunction(Collider other)
    {
        other.transform.DOLocalJump(waypoint.transform.localPosition, 4f, 1, 0.2f);
        other.transform.SetParent(transform.gameObject.transform);
        other.transform.localScale = other.transform.localScale / 1.25f;
        other.transform.localRotation = Quaternion.Euler(0,90,0);
        other.GetComponent<LegoAnimation>().enabled = false;
        other.GetComponent<BoxCollider>().enabled = false;
        waypoint.transform.position += new Vector3(0, 0.44f, 0);
        collectedItems.Add(other.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "CollectableLego":
                
               
                stackFunction(other);
                collectedLegos = collectedLegos + 1;

                if (collectedLegos == targetScore)
                {
                    isObjectOpen = true;
                }
                
                
                scoreSlider.value = collectedLegos;
                
                if (!isPunch && collectedLegos < targetScore)
                {
                    isPunch = true;
                    legoIcon.transform.DOPunchScale(Vector3.one * 0.5f, 0.5f, 1, 1f).OnComplete((() => 
                            isPunch = false
                        ));

                }
               
                break;
            
            
            case "Gold":
                goldAmount++;
                goldAmountText.text = goldAmount.ToString();
                Destroy(other.gameObject);
                if (!goldPunch)
                {
                    goldPunch = true;
                    goldIcon.transform.DOPunchScale(Vector3.one * 1f, 0.5f, 1, 1f).OnComplete((() => 
                            goldPunch = false
                        ));

                }
                
                break;
        }

        
       
    }
    
    
}


