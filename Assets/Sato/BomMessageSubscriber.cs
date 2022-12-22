using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;

/// <summary>
/// 爆弾が爆発したときのメッセージを購読するコンポーネント
/// </summary>
public class BomMessageSubscriber : MonoBehaviour
{
    /// <summary>メッセージを購読した時の処理、BomDataを受け取る</summary>
    public UnityEvent<BomData> OnReceived;

    private void Awake()
    {
        MessageBroker.Default.Receive<BomData>().Subscribe(bomData =>
        {
            OnReceived.Invoke(bomData);
        }).AddTo(this);
    }
}
