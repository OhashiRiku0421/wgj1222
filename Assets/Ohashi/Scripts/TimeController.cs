using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private Text _timeText;

    private float _timer = 0;

    void Update()
    {
        Timer();
    }
    //タイマーの処理とタイマーのテキスト表示
    private void Timer()
    {
        _timer += Time.deltaTime;
        _timeText.text = _timer.ToString("F2");
    }
}
