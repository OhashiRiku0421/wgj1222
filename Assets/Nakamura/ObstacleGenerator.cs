using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_obstaclePrefab;
    [SerializeField] Transform m_generatePoint;

    private bool _generated = false;

    private void Start()
    {
        CenterPositionTrackerSingleton.Instance.OnPositionUpdate.Subscribe(pos => OnPositionUpdate(pos.position)).AddTo(this);
    }
    private void OnPositionUpdate(Vector2 position)
    {
        if (_generated)
            return;

        if (position.y >= m_generatePoint.position.y)
        {
            _generated = true;
            var gobj = Instantiate(m_obstaclePrefab);
            gobj.transform.position = m_generatePoint.position;
        }
    }

    private void Reset()
    {
        m_generatePoint = this.transform;
    }
}
