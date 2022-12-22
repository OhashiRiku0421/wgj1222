using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using DG.Tweening;

/// <summary>
/// シーンで使う音を管理&再生するコンポーネント
/// </summary>
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Serializable]
    public struct SoundData
    {
        [Tooltip("Play()メソッドで呼び出す際のキー")]
        [SerializeField] private string name;
        [Tooltip("Play()メソッドで呼び出す音")]
        [SerializeField] private AudioClip clip;
        [Tooltip("再生時の音量")]
        [SerializeField] private float volume;

        public string Name { get => name; }
        public AudioClip Clip { get => clip; }
        public float Volume { get => volume; }
    }

    /// <summary>AudioSourceコンポーネントを付ける数<summary>
    readonly private int SourcesLength = 10;

    [Header("このシーンで使う音を登録する")]
    [SerializeField] private SoundData[] _sounds;

    private AudioSource[] _sources;
    private Dictionary<string, SoundData> _dic;

    private void Awake()
    {
        // 同じシーン内に2つ以上置く想定をしていないのでif文による分岐は端折っている
        Instance = this;

        _sources = new AudioSource[SourcesLength];
        for (int i = 0; i < SourcesLength; i++)
            _sources[i] = gameObject.AddComponent<AudioSource>();

        _dic = _sounds.ToDictionary(soundData => soundData.Name, soundData => soundData);
    }

    /// <summary>文字列でkeyを指定してSEを再生</summary>
    public void PlaySE(string key)
    {
        if (_dic.TryGetValue(key, out SoundData data))
        {
            // 音を鳴らす間隔の設定をしていないので連続して音が鳴るようになっている
            AudioSource source = GetAudioSource();
            source.clip = data.Clip;
            source.volume = data.Volume;
            source.Play();
        }
        else
        {
            Debug.LogWarning("音が登録されていません: " + key);
        }
    }

    /// <summary>文字列でKeyを指定してBGMを再生</summary>
    public void PlayBGM(string key)
    {
        if (_dic.TryGetValue(key, out SoundData data))
        {
            // 音を鳴らす間隔の設定をしていないので連続して音が鳴るようになっている
            AudioSource source = _sources[SourcesLength - 1];
            source.clip = data.Clip;
            source.volume = data.Volume;
            source.loop = true;
            source.Play();
        }
        else
        {
            Debug.LogWarning("音が登録されていません: " + key);
        }
    }

    /// <summary>BGMをフェードアウトさせる</summary>
    public void FadeOutBGM(float duration = 0.5f)
    {
        _sources[SourcesLength - 1].DOFade(0, duration);
    }

    /// <summary>使用していないAudioSourceを返す</summary>
    private AudioSource GetAudioSource()
    {
        // 一番後ろのAudioSourceはBGM用に取っておく
        for (int i = 0; i < SourcesLength - 1; i++)
            if (!_sources[i].isPlaying)
                return _sources[i];

        return null;
    }
}
