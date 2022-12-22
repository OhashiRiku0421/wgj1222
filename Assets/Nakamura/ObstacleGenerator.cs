using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_obstaclePrefab;
    [SerializeField] Transform m_generatePoint;


    private float _generateXOffset;

    private bool _generated = false;

    private void Start()
    {
        _generateXOffset = m_generatePoint.position.x;
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
            var pos = m_generatePoint.position;
            pos.x = position.x + (_generateXOffset/* * Mathf.Sign(UnityEngine.Random.Range(-1, 1))*/);
            gobj.transform.position = pos;
        }
    }

    private void Reset()
    {
        m_generatePoint = this.transform;
    }
}
