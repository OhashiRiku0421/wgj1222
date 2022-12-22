using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTest : MonoBehaviour
{
    [SerializeField]
    private Text _timeText;

    private float _timer = 0;

    void Update()
    {
        Timer();
    }
    //�^�C�}�[�̏����ƃ^�C�}�[�̃e�L�X�g�\��
    private void Timer()
    {
        _timer += UnityEngine.Time.deltaTime;
        _timeText.text = _timer.ToString("F2");
    }
}
