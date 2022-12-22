using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// ���ז��L�����𐧌䂷��R���|�[�l���g
/// </summary>
public class TrapController : MonoBehaviour
{
    /// <summary>���B������������ʊO��X���W</summary>
    private readonly float _toEscapePosX = -20;

    [Header("��ʒ����ɗ���܂łɂ����鎞��")]
    [SerializeField] private float _toCenterDuration;
    [Header("��ʒ����ɂƂǂ܂鎞��")]
    [SerializeField] private float _waitScreenCenter;
    [Header("��ʒ����Ɉړ�����ۂ̃C�[�W���O")]
    [SerializeField] private Ease _toCenterEase;
    [Space(10)]
    [Header("��ʊO�ɏ�����܂łɂ����鎞��")]
    [SerializeField] private float _toEscapeDuration;
    [Header("��ʒ����Ɉړ�����ۂ̃C�[�W���O")]
    [SerializeField] private Ease _toEscapeEase;

    private Sequence _seq;

    private void Start()
    {
        _seq = DOTween.Sequence()
                      .Append(transform.DOMoveX(0, _toCenterDuration).SetEase(_toCenterEase))
                      .Append(transform.DOMoveX(_toEscapePosX, _toEscapeDuration).SetEase(_toEscapeEase).SetDelay(_waitScreenCenter))
                      .AppendCallback(() => Destroy(gameObject));
    }

    private void OnDestroy()
    {
        _seq.Kill();
    }
}
