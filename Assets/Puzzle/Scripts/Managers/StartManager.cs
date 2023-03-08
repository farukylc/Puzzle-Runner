using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public JsonController _jsonController;
    int currentLevel;
    void Start()
    {
        _jsonController.JsonLoad();
        currentLevel = _jsonController.user1.level;
        //SceneManager.LoadScene((currentLevel-1));
    }

    void Update()
    {
        
    }
    public void StartLastLevel()
    {
        SceneManager.LoadScene((currentLevel-1));
    }
    public void StartLevel1()
    {
        SceneManager.LoadScene(0);
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene(4);
    }
}
