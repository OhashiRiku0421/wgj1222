using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System;

public class CenterPositionManager : MonoBehaviour
{
    // ���S�ʒu�ύX���ɁA�Ă��Ƃ��ɒl��n�����߂̃}�l�[�W���[

    private void Start()
    {
        CenterPositionTrackerSingleton.Instance.OnPositionUpdate
            .Subscribe((pos_tupple) => OnPositionUpdated(pos_tupple.position, pos_tupple.position_before)).AddTo(this);
    }
    private void OnPositionUpdated(Vector2 position, Vector2 position_before)
    {
        
    }
}
