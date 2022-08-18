using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 周囲を怖がらせるオブジェクト
/// </summary>
public class Scaring : MonoBehaviour
{
    Collider2D _collider2D = null;

    /// <summary>
    /// 怖がらせる行動の有効時間
    /// </summary>
    [SerializeField]
    float _scaringTime = 1.0f;

    /// <summary>
    /// 怖がらせる行動の残り有効時間
    /// </summary>
    float _remainingScaringTime = 0.0f;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (IsScaring())
        {
            _remainingScaringTime -= Time.deltaTime;
            if (!IsScaring())
            {
                EndScaring();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                StartScaring();
            }
        }
    }

    /// <summary>
    /// 怖がらせる行動を開始する
    /// </summary>
    private void StartScaring()
    {
        _remainingScaringTime = _scaringTime;
        _collider2D.enabled = true;

        Debug.Log("Start Scaring");
    }

    /// <summary>
    /// 怖がらせる行動を終了する
    /// </summary>
    private void EndScaring()
    {
        _collider2D.enabled = false;

        Debug.Log("End Scaring");
    }

    /// <summary>
    /// 怖がらせる行動の最中である
    /// </summary>
    /// <returns></returns>
    private bool IsScaring()
    {
        return _remainingScaringTime > 0.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AdultController adult = collision.GetComponent<AdultController>();
        if (adult)
        {
            adult._isSurprised = true;
        }
    }
}
