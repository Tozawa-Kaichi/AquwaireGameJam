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
    /// スプライトレンダラー
    /// </summary>
    protected SpriteRenderer _spriteRenderer = null;

    /// <summary>
    /// アニメーター
    /// </summary>
    protected Animator _animator = null;

    protected virtual void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    protected virtual void LateUpdate() { }
}
