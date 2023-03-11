using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public JsonController _jsonController;
    public GameObject buttonContinue,
                      level1Objects,
                      level1Case,
                      level2Image,
                      level2QuestionMark,
                      level2Objects,
                      level2Case, 
                      level3Image,
                      level3QuestionMark,
                      level3Objects,
                      level3Case;
    public Animator _animator;
    int currentLevel;
    void Start()
    {
        _jsonController.JsonLoad();
        currentLevel = _jsonController.user1.level;
        if(currentLevel>1)
        {
            //level1Objects.SetActive(true);
            buttonContinue.SetActive(true);
        }
        // if(currentLevel==1)
        //     StartLevel1();
        switch(currentLevel)
        {
            case 1:
                StartLevel1();
            break;
            case 2:
                Level2Design();
            break;
            case 3:
                Level2Design();
                Level3Design();
            break;
            case 4:
                Level2Design();
                Level3Design();
                Level4Design();
            break;
            case 5:
                Level2Design();
                Level3Design();
                Level4Design();
                Level5Design();
            break;
        }
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
        StartCoroutine(LoadLevel(1));
        //SceneManager.LoadScene(1);
    }
    public void StartLevel2()
    {
        StartCoroutine(LoadLevel(3));
        //SceneManager.LoadScene(3);
    }
    public void StartLevel3()
    {
        StartCoroutine(LoadLevel(5));
        //SceneManager.LoadScene(5);
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        _animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }
    void Level2Design()
    {
        level2QuestionMark.SetActive(false);
        level2Image.SetActive(true);
    }
    void Level3Design()
    {
        level1Case.SetActive(false);
        level1Objects.SetActive(true);
    }
    void Level4Design()
    {
        level3QuestionMark.SetActive(false);
        level3Image.SetActive(true);
    }
    void Level5Design()
    {
        level2Case.SetActive(false);  
        level2Objects.SetActive(true);
    }
}
