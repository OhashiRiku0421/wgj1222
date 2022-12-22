using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System;

public class InGameManager : MonoBehaviour
{
    #region Singleton
    private static InGameManager _instance;
    public static InGameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InGameManager>();
            }
            return _instance;
        }
    }
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


    [SerializeField] InGameStartEffect m_effect;

    private readonly Subject<Unit> _onStartEffectCompleted = new ();
    public IObservable<Unit> OnStartEffectCompleted => _onStartEffectCompleted;


    private IEnumerator Start()
    {
        yield return m_effect.EffectCoroutine();
        _onStartEffectCompleted.OnNext(Unit.Default);
        SoundManager.Instance.PlayBGM("ÉCÉìÉQÅ[ÉÄBGM");
    }
}
