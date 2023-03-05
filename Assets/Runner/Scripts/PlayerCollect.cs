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
    // [SerializeField] public int bonusScore = 0;
    [SerializeField] public bool isObjectOpen = false;
     
    //UI
    [SerializeField] private GameObject smoke;
    [SerializeField] public int goldAmount = 0;
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

    // private void stackFunction(Collider other)
    // {
    //     other.transform.DOLocalJump(waypoint.transform.localPosition, 1.5f, 1, 0.2f);
    //     other.transform.SetParent(transform.gameObject.transform);
    //     other.transform.localScale = other.transform.localScale / 1.25f;
    //     other.transform.localRotation = Quaternion.Euler(0,90,0);
    //     other.GetComponent<LegoAnimation>().enabled = false;
    //     other.GetComponent<BoxCollider>().enabled = false;
    //     waypoint.transform.position += new Vector3(0, 0f, 1f); //y 0.44f
    //     collectedItems.Add(other.gameObject);
    // }
    public void Collect(GameObject obj)
    {
        collectedLegos = collectedLegos + 1;
        scoreSlider.value = collectedLegos;
        if(!collectedItems.Contains(obj))
        {
        //objectCount++;
        
        obj.transform.parent = transform.parent.GetChild(0).transform;
        collectedItems.Add(obj);
        
        collectedItems[collectedItems.Count-1].transform.localPosition = new Vector3(0,0,collectedItems.Count*0.5f);
        if(collectedItems.Count == 1)
        {
            collectedItems[0].gameObject.GetComponent<SmoothDamp>().SetCurrentLeadTransform(transform);
        }
        else
        {
            collectedItems[collectedItems.Count - 1].gameObject.GetComponent<SmoothDamp>().SetCurrentLeadTransform(collectedItems[collectedItems.Count - 2].transform);
        }
        StartCoroutine(MakecollectedItemsBigger());
        }
    }
    public void DropObject()
    {
        if(collectedItems.Count==0)
        {

        }
        else
        {
            //objectCount--;
            GameObject lastObject = collectedItems[collectedItems.Count-1];
            lastObject.SetActive(false);
            lastObject.transform.parent = null;
            collectedItems.Remove(lastObject);
            Destroy(lastObject);
        }     
    }
    public IEnumerator MakecollectedItemsBigger()
    {
        for (int i = collectedItems.Count-1; i > 0; i--)
        {
            int index = i;
            Vector3 scale = Vector3.one;
            scale*=1.5f;
            collectedItems[index].transform.DOScale(scale,0.1f).OnComplete(()=>collectedItems[index].transform.DOScale(Vector3.one,0.1f));
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "CollectableLego":
                
                Collect(other.gameObject);
                
                
                // stackFunction(other);
                

                if (collectedLegos == targetScore)
                {
                    isObjectOpen = true;
                }
                
                
                
                
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


