using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UniRx;
//using System;

public class BGMovementController : MonoBehaviour
{
    [SerializeField] Transform m_camera;
    [SerializeField] float m_max = 5f;
    [SerializeField] float m_effectness = 0.5f;
    [SerializeField] float m_speed = 1f;
    [SerializeField] float m_drag = 0.5f;
    [Header("Debugging")]
    [SerializeField] float velocity = 0f;
    [SerializeField] float position = 0f;

    float cposBefore = 0f;

    new Transform transform;
    private void Start()
    {
        transform = base.transform;
        //CenterPositionTrackerSingleton.Instance.Position.Subscribe(pos_tupple => AddPosition(pos_tupple.position.x));
    }

    private void LateUpdate()
    {
        float cpos = m_camera.position.x;
        AddPosition(cpos - cposBefore);
        cposBefore = cpos;

        float diff = -position;
        velocity += diff * m_speed * Time.deltaTime;
        velocity *= (1f - m_drag * Time.deltaTime);
        position += velocity * Time.deltaTime;

        position = Mathf.Clamp(position, -m_max, +m_max);

        transform.position = new(cpos + position, transform.position.y);
    }

    public void AddPosition(float xpos)
    {
        position += xpos * m_effectness;
    }
}
