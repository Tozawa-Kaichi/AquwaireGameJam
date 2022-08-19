using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��l�X�|�i�[
/// </summary>
public class AdultSpawner : MonoBehaviour
{
    [Header("�����_�����Ԃ̍ŏ��l"), SerializeField] float _minValue;
    [Header("�����_�����Ԃ̍ő�l"), SerializeField] float _maxValue;
    [Header("�������ׂ���l�̃v���n�u"), SerializeField] GameObject _adultPrefab;
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

    /// <summary> �C���^�[�o�����Ԃ�ݒ肷�� </summary>
    /// <returns> �ݒ肳�ꂽ���� </returns>
    float SetInterval()
    {
        return _interval = UnityEngine.Random.Range(_minValue, _maxValue);
    }

    /// <summary> �C���^�[�o����҂� </summary>
    IEnumerator WaitInterval()
    {
        _iaSpawn = false;

        yield return new WaitForSeconds(_interval);

        _iaSpawn = true;
    }
}