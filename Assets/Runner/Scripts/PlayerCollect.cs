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
    private bool isPunch = false;
    private bool goldPunch = false;
    [SerializeField] public bool isObjectOpen = false;
     
    //UI
    [SerializeField] public int goldAmount = 0;
    [SerializeField] private Image goldIcon;
    [SerializeField] private TextMeshProUGUI goldAmountText;
    
    //Lists
    [SerializeField] public List<GameObject> collectedItems = new List<GameObject>();
    private void Start()
    {
        playerCollectScript = this;
    }
    
    public void Collect(GameObject obj)
    {
        collectedLegos = collectedLegos + 1;
       
        if(!collectedItems.Contains(obj))
        {
            obj.GetComponent<LegoAnimation>().enabled = false;
            obj.transform.parent = transform.parent.GetChild(0).transform; 
            obj.transform.localRotation = Quaternion.Euler(0,90,0);
            collectedItems.Add(obj);
            
            collectedItems[collectedItems.Count-1].transform.localPosition = new Vector3(0,0,collectedItems.Count*0.7f);
            if(collectedItems.Count == 1)
            {
                collectedItems[0].gameObject.GetComponent<SmoothDamp>().SetCurrentLeadTransform(transform);
            }
            else
            {
                collectedItems[collectedItems.Count - 1].gameObject.GetComponent<SmoothDamp>().SetCurrentLeadTransform(collectedItems[collectedItems.Count - 2].transform);
            }
            // StartCoroutine(MakecollectedItemsBigger());
        }
    }

    public void DropObject()
    {
        if(collectedItems.Count==0)
        {

        }
        else
        {
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
            break;
            
            case "Gold":
                goldAmount++;
                Destroy(other.gameObject);

                goldAmountText.text = goldAmount.ToString();
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


