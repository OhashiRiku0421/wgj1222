using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;

/// <summary>
/// ���e�����������Ƃ��̃��b�Z�[�W���w�ǂ���R���|�[�l���g
/// </summary>
public class BomMessageSubscriber : MonoBehaviour
{
    /// <summary>���b�Z�[�W���w�ǂ������̏����ABomData���󂯎��</summary>
    public UnityEvent<BomData> OnReceived;

    private void Awake()
    {
        MessageBroker.Default.Receive<BomData>().Subscribe(bomData =>
        {
            OnReceived.Invoke(bomData);
        }).AddTo(this);
    }
}
