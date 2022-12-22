using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPositionDummyClickPoint : MonoBehaviour
{
    [SerializeField] Camera m_camera;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CenterPositionTrackerSingleton.Instance.CheckPosition(m_camera.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
