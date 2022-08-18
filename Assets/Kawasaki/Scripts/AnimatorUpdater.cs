using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アニメーターを更新するもの
/// </summary>
[RequireComponent(typeof(Animator))]
public class AnimatorUpdater : MonoBehaviour
{
    /// <summary>
    /// アニメーター
    /// </summary>
    protected Animator _animator = null;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected virtual void LateUpdate()
    {
    }
}
