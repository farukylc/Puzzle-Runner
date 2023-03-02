using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RunnerButtons : MonoBehaviour
{
    [SerializeField] private GameObject newCharcterPanel;
    public void newCharacterAnim()
    {
        newCharcterPanel.transform.DOMove(ObjectBuilder.objectBuilderScript.winPanel.transform.position, 2);
        
    }
}
