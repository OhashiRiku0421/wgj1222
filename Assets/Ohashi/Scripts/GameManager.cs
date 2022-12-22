using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool _isResult;

    public bool IsResult { get => _isResult; set => _isResult = value; }

    private void Awake()
    {
        //�V���O���g��
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(Instance);
        }
    }

    /// <summary>
    /// ���U���g�V�[����
    /// </summary>
    public void ResultGameObject(GameObject player)
    {
        player.transform.parent = transform;
    }
}
