using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System;

public class BombController : MonoBehaviour
{
    [SerializeField] StickyMovementController m_movementController;
    [SerializeField] BomMessagePublisher m_messagePublisher;

    private void Start()
    {
        m_movementController.OnSticked.Skip(1).Subscribe(_ => { m_messagePublisher.Publish(); /*Debug.Log("a");*/ }).AddTo(this);
    }
}
