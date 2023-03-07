using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SmoothDamp : MonoBehaviour
{
    public Transform currentLeadTransform;
    PlayerCollect _playerCollect;
    private float currentVelocity=0.0f;
    
    void Start()
    {
        //_playerCollect = GameObject.FindWithTag("Player").GetComponent<PlayerCollect>();
        //_playerCollect = RLMove.instance.playerTransform.gameObject.GetComponent<PlayerCollect>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLeadTransform == null) return;
        else
        {
            transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x,currentLeadTransform.position.x,ref currentVelocity,0.05f),transform.position.y,transform.position.z);
        }
    }

    public void SetCurrentLeadTransform(Transform leadTransform)
    {
        currentLeadTransform = leadTransform;
    }
    private void OnTriggerEnter(Collider other) {
        // if(other.CompareTag("Finish"))
        // {
        //     _player.score+=1;
        //     _player.text.text = $"{_player.score} metre ilerledin";
        //     _player.StackObject();
        //     gameObject.GetComponent<Collider>().enabled = false;
        // }
        if(other.CompareTag("CollectableLego"))
        {
            _playerCollect.Collect(other.gameObject);
        }

        if (other.CompareTag("Gold"))
        {
            PlayerCollect.playerCollectScript.goldAmount++;
            other.transform.DOLocalMove(PlayerCollect.playerCollectScript.goldAmountText.transform.position, 1f).OnComplete((() => 
                Destroy(other.gameObject)));
            
        
            PlayerCollect.playerCollectScript.goldAmountText.text =  PlayerCollect.playerCollectScript.goldAmount.ToString();
            if (! PlayerCollect.playerCollectScript.goldPunch)
            {
                PlayerCollect.playerCollectScript.goldPunch = true;
                PlayerCollect.playerCollectScript.goldIcon.transform.DOPunchScale(Vector3.one * 1f, 0.5f, 1, 1f).OnComplete((() => 
                        PlayerCollect.playerCollectScript.goldPunch = false
                    
                    ));
        
            }
            
        }
        //
        // else if(other.CompareTag("Obstacle1"))
        // {
        //     _player.DropObject();
        // }
    }
    public void SetPlayer(GameObject obj)
    {
        _playerCollect = obj.GetComponent<PlayerCollect>();
    }
}
