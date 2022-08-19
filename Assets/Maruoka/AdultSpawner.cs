using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 大人スポナー
/// </summary>
public class AdultSpawner : MonoBehaviour
{
    [Header("ランダム時間の最小値"), SerializeField] float _minValue;
    [Header("ランダム時間の最大値"), SerializeField] float _maxValue;
    [Header("生成すべき大人のプレハブ"), SerializeField] GameObject _adultPrefab;
    float _interval;
    bool _iaSpawn = false;

    void Start()
    {
        SetInterval();
        StartCoroutine(WaitInterval());
    }

    void Update()
    {
        if (_iaSpawn)
        {
            SetInterval();
            StartCoroutine(WaitInterval());
            Instantiate(_adultPrefab, transform.position, Quaternion.identity);
        }
    }

    /// <summary> インターバル時間を設定する </summary>
    /// <returns> 設定された時間 </returns>
    float SetInterval()
    {
        return _interval = UnityEngine.Random.Range(_minValue, _maxValue);
    }

    /// <summary> インターバルを待つ </summary>
    IEnumerator WaitInterval()
    {
        _iaSpawn = false;

        yield return new WaitForSeconds(_interval);

        _iaSpawn = true;
    }
}