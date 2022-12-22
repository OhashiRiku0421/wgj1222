using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �Q�[���X�^�[�g���̉��o���s���R���|�[�l���g
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
        // ���Ȃ̂�1�b��Ƀe�L�X�g�������邾���̉��o

        _text.text = "GameStart";
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }
}
