using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System;

public class TimeController : MonoBehaviour
{
    [SerializeField] float m_time = 30f;

    [Header("Debugging")]
    [SerializeField] float timer;

    public float Timer { get => timer; set => timer = value; }

    private readonly ReactiveProperty<float> _onTimerUpdated = new ReactiveProperty<float>();
    public IObservable<float> OnTimerUpdated => _onTimerUpdated;

    private readonly Subject<Unit> _onTimerComplete = new Subject<Unit>();
    public IObservable<Unit> OnTimerComplete => _onTimerComplete;


    bool _isPlaying;


    private void Awake()
    {
        _isPlaying = false;
        InGameManager.Instance.OnStartEffectCompleted.Subscribe(_ => OnGameStart()).AddTo(this);
    }
    private void OnGameStart()
    {
        StartTimer();
        _isPlaying = true;
    }

    private void StartTimer()
    {
        timer = m_time;
    }

    private void LateUpdate()
    {
        if (_isPlaying == false)
            return;

        timer -= Time.deltaTime;
        timer = Mathf.Max(timer, 0f);
        _onTimerUpdated.Value = timer;
        if (timer <= 0)
        {
            _onTimerComplete.OnNext(Unit.Default);
            this.enabled = false;
        }
    }
}
