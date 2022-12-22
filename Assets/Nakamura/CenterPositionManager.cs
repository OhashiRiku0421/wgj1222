using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System;

public class CenterPositionManager : MonoBehaviour
{
    // 中心位置変更時に、てきとうに値を渡すためのマネージャー

    private void Start()
    {
        CenterPositionTrackerSingleton.Instance.OnPositionUpdate
            .Subscribe((pos_tupple) => OnPositionUpdated(pos_tupple.position, pos_tupple.position_before)).AddTo(this);
    }
    private void OnPositionUpdated(Vector2 position, Vector2 position_before)
    {
        
    }
}
