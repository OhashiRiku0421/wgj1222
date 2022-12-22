using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// お邪魔キャラを制御するコンポーネント
/// </summary>
public class TrapController : MonoBehaviour
{
    /// <summary>到達したら消える画面外のX座標</summary>
    private readonly float _toEscapePosX = -20;

    [Header("画面中央に来るまでにかかる時間")]
    [SerializeField] private float _toCenterDuration;
    [Header("画面中央にとどまる時間")]
    [SerializeField] private float _waitScreenCenter;
    [Header("画面中央に移動する際のイージング")]
    [SerializeField] private Ease _toCenterEase;
    [Space(10)]
    [Header("画面外に消えるまでにかかる時間")]
    [SerializeField] private float _toEscapeDuration;
    [Header("画面中央に移動する際のイージング")]
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
