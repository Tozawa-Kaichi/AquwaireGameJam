using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 大人の引っかかり対策
/// </summary>
public class AdultCatchingMeasures : MonoBehaviour
{
    [Header("引っかかりを判定するまでの時間"), SerializeField] float _caughtTime;
    float _timer;
    /// <summary> 基準のマグニチュード </summary>
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
