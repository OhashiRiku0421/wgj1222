using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームスタート時の演出を行うコンポーネント
/// </summary>
public class InGameStartEffect : MonoBehaviour
{
    [SerializeField] private Text _text;

    private void Awake()
    {
        _text.text = "";
    }

    public IEnumerator EffectCoroutine()
    {
        // 仮なので1秒後にテキストが消えるだけの演出

        _text.text = "GameStart";
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }
}
