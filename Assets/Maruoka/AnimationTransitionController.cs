using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> アニメーション遷移のコントローラー </summary>
public class AnimationTransitionController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    Animator _animator;

    [Header("アニメーションパラメータの名前 : アイドル"), SerializeField] string _animParam_idle = "IsIdele";
    [Header("アニメーションパラメータの名前 : 右へ移動しているか"), SerializeField] string _animParam_MoveRight = "IsMoveRight";
    [Header("アニメーションパラメータの名前 : 左へ移動しているか"), SerializeField] string _animParam_MoveLeft = "IsMoveLeft";
    [Header("アニメーションパラメータの名前 : 上へ移動しているか"), SerializeField] string _animParam_MoveUp = "IsMoveUp";
    [Header("アニメーションパラメータの名前 : 下へ移動しているか"), SerializeField] string _animParam_MoveDown = "IsMoveDown";

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _animator.SetBool(_animParam_idle, false);
        _animator.SetBool(_animParam_MoveUp, false);
        _animator.SetBool(_animParam_MoveDown, false);
        _animator.SetBool(_animParam_MoveRight, false);
        _animator.SetBool(_animParam_MoveLeft, false);

        if (_rigidbody2D.velocity == Vector2.zero)
        {
            _animator.SetBool(_animParam_idle, true);
        }
        //上を判定する
        else if (_rigidbody2D.velocity.y > 0)
        {
            _animator.SetBool(_animParam_MoveUp, true);
        }
        //下を判定する
        else if (_rigidbody2D.velocity.y < 0)
        {
            _animator.SetBool(_animParam_MoveDown, true);
        }
        //右を判定する
        else if (_rigidbody2D.velocity.x > 0)
        {
            _animator.SetBool(_animParam_MoveRight, true);
        }
        // 左を判定する
        else　if(_rigidbody2D.velocity.x < 0)
        {
            _animator.SetBool(_animParam_MoveLeft, true);
        }
    }
}
