using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System;

public class StickyMovementController : MonoBehaviour, IStickable
{
    [SerializeField] string m_stickTargetTag = "Player";
    [SerializeField] Rigidbody2D m_rigidbody2D;
    [SerializeField] string m_seKey = "êHçﬁïtíÖSE";

    private const float DestroyHeight = -10f;

    private readonly ReactiveProperty<Vector2>  _onSticked = new ();
    public IObservable<Vector2> OnSticked => _onSticked;


    new Transform transform;

    private void Awake()
    {
        transform = base.transform;
    }

    private void FixedUpdate()
    {
        if (transform.position.y < DestroyHeight)
            Destroy(this.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(m_stickTargetTag))
        {
            OnCollideWithTarget(collision);
        }
    }

    private void OnCollideWithTarget(Collision2D collision) 
    {
        Vector2 pos = this.transform.position;

        Destroy(m_rigidbody2D);
        this.transform.rotation = Quaternion.identity;
        this.transform.parent = collision.transform;
        CenterPositionTrackerSingleton.Instance.CheckPosition(pos);
        _onSticked.Value = pos;

        SoundManager.Instance.PlaySE(m_seKey);
    }

    private void Reset()
    {
        m_rigidbody2D = this.GetComponent<Rigidbody2D>();
    }
}
