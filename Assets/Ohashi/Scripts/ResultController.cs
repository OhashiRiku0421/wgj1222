using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    GameManager _gameManager;
    PlayerMovementController _player;

    void Start()
    {
        _gameManager = GameManager.Instance;
        _gameManager.IsResult = true;
        SoundManager.Instance.PlayBGM("ResultBGM");
        _player = FindObjectOfType<PlayerMovementController>();
    }

    void Update()
    {
        if(Camera.main.orthographicSize <= _player.transform.childCount)
        {
            Camera.main.orthographicSize += 0.01f;
        }
    }
    public void TitleReset()
    {
        Destroy(_gameManager.gameObject);
        Destroy(gameObject);
        SoundManager.Instance.PlaySE("ResultSE");
        FadeSystem.Instance.FadeOut("Merge_Title");
    }
}
