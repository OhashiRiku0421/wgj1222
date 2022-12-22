using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;
using System;

/// <summary>
/// ���e�����������Ƃ��̃��b�Z�[�W���w�ǂ���R���|�[�l���g
/// </summary>
public class BomMessageSubscriber : MonoBehaviour
{
    private IDisposable _disposable;

    /// <summary>���b�Z�[�W���w�ǂ������̏����ABomData���󂯎��</summary>
    public UnityEvent<BomData> OnReceived;

    private void Awake()
    {
        _disposable = MessageBroker.Default.Receive<BomData>().Subscribe(bomData =>
        {
            OnReceived.Invoke(bomData);
        });
    }

    private void OnDestroy()
    {
        _disposable.Dispose();
    }
}
