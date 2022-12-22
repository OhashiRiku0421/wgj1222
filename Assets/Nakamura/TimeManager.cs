using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TimeController m_timeController;
    [SerializeField] BomMessageSubscriber m_bomMessageSubscriber;

    private void Awake()
    {
        m_bomMessageSubscriber.OnReceived.AddListener(OnBomMessageReceived);
    }
    private void OnDestroy()
    {
        m_bomMessageSubscriber.OnReceived.RemoveListener(OnBomMessageReceived);
    }

    private void OnBomMessageReceived(BomData data)
    {
        m_timeController.Timer -= data.Penalty;
    }
}
