using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Rigidbody2D rigid;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        EventCenterManager.Instance.AddEventListener<bool>(GameEvent.CollectableEnterSpace,AdjustGravityScale);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag(PlayerProperties.Instance.PLAYER_TAG))
            EventCenterManager.Instance.EventTrigger(GameEvent.ExistCollectable,gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag(PlayerProperties.Instance.PLAYER_TAG))
            EventCenterManager.Instance.EventTrigger(GameEvent.NonExistCollectable,gameObject);
    }

    private void AdjustGravityScale(bool isCollectableEnterSpace)
    {
        rigid.gravityScale = isCollectableEnterSpace ? 0 : 1;
    }
    
}