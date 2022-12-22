using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System;

public class CenterPositionTrackerSingleton : MonoBehaviour
{
    #region Singleton
    private static CenterPositionTrackerSingleton _instance;
    public static CenterPositionTrackerSingleton Instance { 
        get { 
            if (_instance == null)
            {
                _instance = FindObjectOfType<CenterPositionTrackerSingleton>();
            }
            return _instance;
        } }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        _instance = null;
    }
    private void OnDestroy()
    {
        _instance = null;
    }
    #endregion


    [Header("Debugging")]
    [SerializeField] float highestPosition = float.NegativeInfinity;


    private readonly ReactiveProperty<(Vector2 position, Vector2 position_before)> _position = new ();
    public IObservable<(Vector2 position, Vector2 position_before)> OnPositionUpdate => _position;




    //public IDisposable AddPositionObservable(IObservable<Vector2> positionObservable)
    //{
    //    return positionObservable.Subscribe(CheckPosition).AddTo(this);
    //}

    public void CheckPosition(Vector2 position)
    {
        if (position.y > highestPosition)
        {
            highestPosition = position.y;
            UpdatePosition(position);
        }
    }
    private void UpdatePosition(Vector2 position)
    {
        (_, Vector2 position_before) = _position.Value;
        _position.Value = (position, position_before);


    }
}
