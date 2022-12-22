using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    float _interval = 3f;
    [SerializeField]
    string _sceneName;

    TimeController _timeController;
    Image _image;
    void Start()
    {
        _timeController = GameObject.FindObjectOfType<TimeController>();
        _image = GetComponent<Image>();
    }

    void Update()
    {
        if(_timeController.Timer <= 0)
        {
            _image.enabled = true;
            StartCoroutine(ResultInterval());
        }
    }
    IEnumerator ResultInterval()
    {
        yield return new WaitForSeconds(_interval);
        FadeSystem.Instance.FadeOut(_sceneName);

    }
}
