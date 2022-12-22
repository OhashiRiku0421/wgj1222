using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

/// <summary>
/// DotWeenを使用したフェードを行うコンポーネント
/// </summary>
public class FadeSystem : MonoBehaviour
{
    public static FadeSystem _instance;

    [SerializeField] private RawImage _img;
    [Header("フェードにかかる時間")]
    [SerializeField] private float _time;

    private bool _isFading;
    /// <summary>フェード中かどうか</summary>
    public bool IsFading { get => _isFading; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.activeSceneChanged += FadeIn;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= FadeIn;
    }

    private void FadeIn(Scene _, Scene __)
    {
        if (_isFading) return;

        _img.DOFade(0, _time)
            .OnStart(() =>
            {
                _isFading = true;
            })
            .OnComplete(() =>
            {
                _isFading = false;
                _img.enabled = false;
            });
    }

    /// <summary>
    /// DotWeenを使用したフェードアウト
    /// </summary>
    /// <param name="scene">次のシーン名</param>
    public void FadeOut(string scene)
    {
        if (_isFading) return;

        _img.DOFade(1, _time)
            .OnStart(() =>
            {
                _isFading = true;
                _img.enabled = true;
            })
            .OnComplete(() =>
            {
                _isFading = false;

                SceneManager.LoadScene(scene);
            });
    }
}
