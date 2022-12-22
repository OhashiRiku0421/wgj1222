using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

using UniRx;
using System;

public class CameraInGameController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCameraBase m_vcamera;

    private GameObject targetGobj;
    private Transform targetTransform;

    private void Start()
    {
        targetGobj = new GameObject("target");
        targetTransform = targetGobj.transform;
        var pos = targetTransform.position;
        pos.z = this.transform.position.z;
        targetTransform.position = pos;

        CenterPositionTrackerSingleton.Instance.OnPositionUpdate.Subscribe(position => OnCenterUpdated(position.position)).AddTo(targetGobj);

        m_vcamera.Follow = targetTransform;
    }

    private void OnCenterUpdated(Vector2 position)
    {
        var pos = new Vector3(position.x, Mathf.Max(targetTransform.position.y, position.y));
        targetTransform.position = pos;
    }

    private void OnDestroy()
    {
        if (targetGobj != null)
        {
            Destroy(targetGobj);
        }
    }
}
