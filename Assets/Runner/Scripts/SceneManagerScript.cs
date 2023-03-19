using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void nextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
            GameManager.instance.isCharacter1Change = GameManager.instance.isCharacter1Change == true ? false : true;
        else if(SceneManager.GetActiveScene().buildIndex == 4)
           GameManager.instance.isCharacter2Change = GameManager.instance.isCharacter2Change == true ? false : true;
        else if(SceneManager.GetActiveScene().buildIndex == 6)
           GameManager.instance.isCharacter3Change = GameManager.instance.isCharacter3Change == true ? false : true;
        GameManager.instance.currentLevel++;
        GameManager.instance.RunnerLevelEndSave();
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)%6);     
    }
}
