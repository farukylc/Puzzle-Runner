using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterController : MonoBehaviour
{
    GameManager _gameManager;
    SceneControlManager _sceneManager;
    private Touch touch;
    Vector3 prevPos = Vector3.zero;
    Vector3 posDelta = Vector3.zero;
    
    void Start()
    {
        _gameManager = GameManager.instance;
        _sceneManager = SceneControlManager.instance;
    }

    [System.Obsolete]
    // void OnMouseDrag() 
    // {
    //     Debug.Log("calisti");
    //     if(_gameManager.isPuzzleComplate)
    //     {
            
    //         float rotX = Input.GetAxis("Mouse X")*rotationSpeed*Mathf.Deg2Rad;
    //         transform.RotateAround(Vector3.up,-rotX);
    //     }
    // }
    void Update()
    {
        if(_gameManager.isPuzzleComplate)
        {
            if(Input.GetMouseButton(0))
            {
                posDelta = Input.mousePosition - prevPos;
                transform.Rotate(transform.up,Vector3.Dot(posDelta,Camera.main.transform.right)*_gameManager.rotationSpeed*-1,Space.World);
            }
            prevPos = Input.mousePosition;
        }
    }
    public void CharacterRotate()
    {
        _gameManager.characterWithAnim.transform.DORotate(new Vector3(0,360,0),0.5f,RotateMode.LocalAxisAdd).SetLoops(3,LoopType.Restart).SetEase(Ease.Linear).OnComplete(()=>
            {
                Instantiate(_gameManager.smoke,_gameManager.characterWithAnim.transform.position+new Vector3(0,5,0),Quaternion.identity);
                _gameManager.characterWithAnim.SetActive(false);
                _gameManager.characterWithAnim.transform.DOMove(Vector3.zero,0.4f).OnComplete(()=>_sceneManager.NextLevel());
            });
    }
}
