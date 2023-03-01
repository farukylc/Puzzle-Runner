using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class RLMove : MonoBehaviour, IDragHandler
{
    public Transform playerTransform;

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = playerTransform.position;
        pos.x = Mathf.Clamp(pos.x + (eventData.delta.x / 100), -5f, 5f);
        playerTransform.position = pos;
    }
}
