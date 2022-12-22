using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    GameManager _gameManager;

    void Start()
    {
        _gameManager = GameManager.Instance;
        _gameManager.IsResult = true;
    }

    void Update()
    {
        if(Camera.main.orthographicSize <=_gameManager.transform.childCount)
        {
            Camera.main.orthographicSize += 0.01f;
        }
    }
    public void TitleReset()
    {
        Destroy(_gameManager.gameObject);
        Destroy(gameObject);
    }
}
