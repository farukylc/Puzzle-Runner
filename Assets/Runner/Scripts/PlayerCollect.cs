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
    //[SerializeField] private GameObject targetPoint;
    private bool isPunch = false;
    [SerializeField] private GameObject smoke;


    [SerializeField] private Slider scoreSlider;
    [SerializeField] private int maxScore;
    [SerializeField] public int targetScore;
    [SerializeField] private Image goldIcon;
    [SerializeField] private Image qmImage;
   // [SerializeField] private Sprite winObject;

    [SerializeField] private TextMeshProUGUI targetScoreText;
    [SerializeField] private TextMeshProUGUI bonusScoreText;

    private int bonusScore = 0;

    private void Start()
    {
        scoreSlider.maxValue = maxScore;
        targetScoreText.text = "0/" + targetScore.ToString();
        bonusScoreText.text = "0/" + (maxScore - targetScore).ToString();
        playerCollectScript = this;
        InvokeRepeating("qmAnimation",1,1);
    }

    private void Update()
    {
        if (targetScore < collectedLegos)
        {
            CancelInvoke("qmAnimation");
           // qmImage.sprite = winObject;
        }
           
    }

    private void qmAnimation()
    {
        if(collectedLegos < targetScore)
            qmImage.transform.DOPunchScale(Vector3.one * 0.5f, 0.5f, 1, 1f);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "CollectableLego":
                GameObject newSomoke = Instantiate(smoke,other.transform.position,Quaternion.identity);
                other.gameObject.SetActive(false);
                
                collectedLegos = collectedLegos + 1;

                if (collectedLegos <= targetScore)
                {
                    targetScoreText.text = collectedLegos.ToString() +"/" +targetScore.ToString();
                }
                else if (targetScore <= collectedLegos && collectedLegos<= maxScore)
                {
                    bonusScore++;
                    bonusScoreText.text = bonusScore.ToString() +"/" +targetScore.ToString();
                }
                
                scoreSlider.value = collectedLegos;
                
                
                if (!isPunch && collectedLegos < targetScore)
                {
                    isPunch = true;
                    legoIcon.transform.DOPunchScale(Vector3.one * 0.5f, 0.5f, 1, 1f).OnComplete((() => 
                            isPunch = false
                        ));

                }
                else if (!isPunch)
                {
                    isPunch = true;
                    goldIcon.transform.DOPunchScale(Vector3.one * 0.5f, 0.5f, 1, 1f).OnComplete((() => 
                            isPunch = false
                        ));

                }
                break;
        }

       
    }
}


