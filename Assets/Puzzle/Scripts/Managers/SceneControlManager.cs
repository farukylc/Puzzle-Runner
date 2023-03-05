using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlManager : MonoBehaviour
{
    public static SceneControlManager instance;
    Scene []puzzleScenes; 
    int currentPuzzleSceneIndex = 0;
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
    public void NextPuzzleLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+4);
    }
    public void PreviousPuzzleLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-4);
    }
    public void NextLevel()//datalari kayit eder runner sahnesine gecer
    {
        GameManager.instance.PuzzleLevelEndSave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
