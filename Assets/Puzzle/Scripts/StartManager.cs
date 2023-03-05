using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public JsonController _jsonController;
    private int currentLevel;

    void Start()
    {
        _jsonController.JsonLoad();
        currentLevel = _jsonController.user1.level;
        SceneManager.LoadScene(currentLevel-1);
    }

    void Update()
    {
        
    }
}
