using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public JsonController _jsonController;
    public GameObject buttonContinue; 
    int currentLevel;
    void Start()
    {
        _jsonController.JsonLoad();
        currentLevel = _jsonController.user1.level;
        if(currentLevel>1)
            buttonContinue.SetActive(true);
        if(currentLevel==1)
            StartLevel1();
        //SceneManager.LoadScene((currentLevel-1));
    }

    void Update()
    {
        
    }
    public void StartLastLevel()
    {
        SceneManager.LoadScene((currentLevel));
    }
    public void StartLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene(5);
    }
}
