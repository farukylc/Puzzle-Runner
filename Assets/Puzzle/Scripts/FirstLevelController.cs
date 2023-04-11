using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstLevelController : MonoBehaviour,IPointerEnterHandler
{
    public static FirstLevelController instance;
    public GameObject scrollAnim, touchAnim, tocuhPanel;

    public void Awake() 
    {
        instance = this;    
    }

    void Start()
    {

    }
    void Update()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("calisti");
        tocuhPanel.SetActive(false);
        touchAnim.SetActive(false);
    }
}
