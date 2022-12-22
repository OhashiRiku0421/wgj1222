using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using UniRx;
using UniRx.Triggers;
using System;

public class StickyObjectGenerator : MonoBehaviour
{
    [System.Serializable]
    public struct StickyItem
    {
        public GameObject StickyObject;
        public float SpawnWeight;
    }

    [SerializeField] StickyItem[] m_stickyItems;


    [SerializeField] float m_spawnRange = 5f;
    [SerializeField] float m_spawnRate = 1f;


    new Transform transform;
    Coroutine coroutine;

    private void Awake()
    {
        transform = base.transform;
    }

    private void Start()
    {
        InGameManager.Instance.OnStartEffectCompleted.Subscribe(_ => coroutine = StartCoroutine(Loop())).AddTo(this);
    }
    private void OnDestroy()
    {
        StopCoroutine(coroutine);
    }


    private IEnumerator Loop()
    {
        while (this != null)
        {
            yield return new WaitForSeconds(m_spawnRate);

            var prefab = NextStickyItem();
            var gobj = Instantiate(prefab);

            Vector3 pos = this.transform.position;
            pos.x = UnityEngine.Random.Range(-m_spawnRange, m_spawnRange);
            gobj.transform.position = pos;
        }
    }


    public GameObject NextStickyItem()
    {
        float weightSize = m_stickyItems.Sum(item => item.SpawnWeight);
        float random_num = UnityEngine.Random.Range(0, weightSize);

        float weight_inRange = 0;
        for (int i = 0; i < m_stickyItems.Length; i++)
        {
            weight_inRange += m_stickyItems[i].SpawnWeight;
            if (random_num < weight_inRange)
            {
                return m_stickyItems[i].StickyObject;
            }
        }
        return m_stickyItems[0].StickyObject;
    }

    private void OnDrawGizmosSelected()
    {
        var gcolor = Gizmos.color;
        Gizmos.color = Color.yellow;
        Vector3 pos = base.transform.position;
        Gizmos.DrawLine(pos + Vector3.left * m_spawnRange, pos + Vector3.right * m_spawnRange);
        Gizmos.color = gcolor;
    }
}
