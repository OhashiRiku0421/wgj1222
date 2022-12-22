using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// 爆弾が爆発した時に発行されるメッセージのデータ
/// </summary>
public struct BomData
{
    public int Penalty { get; }

    public BomData(int penalty)
    {
        Penalty = penalty;
    }
}

/// <summary>
/// 爆弾が爆発した時のメッセージを発行するコンポーネント
/// </summary>
public class BomMessagePublisher : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2.0f);
        MessageBroker.Default.Publish(new BomData(100));
    }
}
