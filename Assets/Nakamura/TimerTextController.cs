using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System;

public class TimerTextController : MonoBehaviour
{
    [SerializeField] TimeController m_timeManager;
    [SerializeField] UnityEngine.UI.Text m_text;

    private void Start()
    {
        m_timeManager.OnTimerUpdated.Subscribe(TimerUpdate).AddTo(this);
    }

    private void TimerUpdate(float timeRemaining)
    {
        m_text.text = timeRemaining.ToString("000.");
    }
}
