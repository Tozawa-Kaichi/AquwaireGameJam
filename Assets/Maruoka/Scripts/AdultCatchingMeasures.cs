using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��l�̈���������΍�
/// </summary>
public class AdultCatchingMeasures : MonoBehaviour
{
    [Header("����������𔻒肷��܂ł̎���"), SerializeField] float _caughtTime;
    float _timer;
    /// <summary> ��̃}�O�j�`���[�h </summary>
    float _standardMagnitude;
    Rigidbody2D _rigidbody2D;

    void Start()
    {
        _standardMagnitude = GetComponent<NPCMove>()._moveSpeed;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_rigidbody2D.velocity.magnitude < _standardMagnitude)
        {
            _timer += Time.deltaTime;
            if (_timer > _caughtTime)
            {
                GetComponent<AdultController>()._isSurprised = true;
            }
        }
        else
        {
            _timer = 0f;
        }
    }
}
