using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class RunnerButtons : MonoBehaviour
{
    [SerializeField] private GameObject newCharcterPanel;
    public void newCharacterAnim()
    {
        newCharcterPanel.transform.DOMove(ObjectBuilder.objectBuilderScript.winPanel.transform.position, 2);
        
    }

    public void goToCatPuzzle()
    {
        SceneManager.LoadScene(4);

    }

    public void nextScene()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    }
}