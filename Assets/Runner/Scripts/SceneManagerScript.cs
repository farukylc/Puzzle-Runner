using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void nextLevel()
    {
        GameManager.instance.RunnerLevelEndSave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
