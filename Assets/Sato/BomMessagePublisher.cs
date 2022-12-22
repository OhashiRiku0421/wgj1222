using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// ���e�������������ɔ��s����郁�b�Z�[�W�̃f�[�^
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
/// ���e�������������̃��b�Z�[�W�𔭍s����R���|�[�l���g
/// </summary>
public class BomMessagePublisher : MonoBehaviour
{
    [Header("�����������Ɍ���c�莞����")]
    [SerializeField] int _penalty;

    public void Publish()
    {
        MessageBroker.Default.Publish(new BomData(_penalty));
    }
}
