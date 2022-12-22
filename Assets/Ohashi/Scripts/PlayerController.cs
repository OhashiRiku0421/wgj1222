using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _moveMax;
    [SerializeField]
    private float _moveMin;
    [SerializeField]
    private float _moveSpeed;

    Vector2 _dir = default;
    Transform _transform;
    GameManager _gameManager;

    void Start()
    {
        _transform = transform;
        _gameManager = GameManager.Instance;
        _gameManager.ResultGameObject(gameObject);
    }

    void Update()
    {
        if(_gameManager.IsResult)
        {
            Move();
            MoveLimit();
        }
    }

    private void Move()
    {
        _dir = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        _transform.Translate(_dir * _moveSpeed * Time.deltaTime);
    }

    private void MoveLimit()
    {
        Vector2 pos = _transform.position;
        pos.x = Mathf.Clamp(pos.x, _moveMin, _moveMax);
        _transform.position = pos;
    }
}
