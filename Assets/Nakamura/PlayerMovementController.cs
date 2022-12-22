using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private float Center_x_position { get; set; } = 0f;

    [SerializeField] private float m_speed = 5f;
    [SerializeField] private float m_moveableRange = 5f;

    [SerializeField] private float position;

    new Transform transform;

    private void Start()
    {
        transform = base.transform;
    }

    private void Update()
    {
        float input = Input.GetAxis("Horizontal");
        float mr_half = m_moveableRange * .5f;

        float min_posX = Center_x_position - mr_half;
        float max_posX = Center_x_position + mr_half;

        position += input * m_speed * Time.deltaTime;
        position = Mathf.Clamp(position, min_posX, max_posX);

        transform.position = new(position, transform.position.y);
    }

    public void Centernize()
    {
        //Debug.Log("aaa");
        Center_x_position = transform.position.x;
    }
}
