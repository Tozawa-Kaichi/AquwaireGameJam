using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> アニメーション遷移のコントローラー </summary>
public class AnimationTransitionController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    protected Animator _animator;

    [Header("アニメーションパラメータの名前 : アイドル"), SerializeField] string _animParam_idle = "IsIdle";
    [Header("アニメーションパラメータの名前 : 右へ移動しているか"), SerializeField] string _animParam_MoveBeside = "IsMoveBeside";
    [Header("アニメーションパラメータの名前 : 上へ移動しているか"), SerializeField] string _animParam_MoveUp = "IsMoveUp";
    [Header("アニメーションパラメータの名前 : 下へ移動しているか"), SerializeField] string _animParam_MoveDown = "IsMoveDown";

    [Header("アニメーションパラメータの名前 : 下へ移動しているか"), SerializeField] protected string _animParamName_AnimSpeed = "AnimSpeed";

    protected bool isRight;
    bool isUp;

    protected virtual void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        SetAnimParamAllFalse();

        if (_rigidbody2D.velocity == Vector2.zero)
        {
            _animator.SetFloat(_animParamName_AnimSpeed, 0f);
        }
        else
        {
            _animator.SetFloat(_animParamName_AnimSpeed, 1f);
            //左右を判定
            if (_rigidbody2D.velocity.x > 0f)
            {
                isRight = true;
            }
            else
            {
                isRight = false;
            }
            //上下を判定
            if (_rigidbody2D.velocity.y > 0f)
            {
                isUp = true;
            }
            else
            {
                isUp = false;
            }

            //どっちの成分が大きいか判定しパラメータを変更する
            //x成分が大きい場合 左右も切り返る
            if (Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Abs(_rigidbody2D.velocity.y))
            {
                _animator.SetBool(_animParam_MoveBeside, true);
                if (isRight)
                {
                    Vector3 s = transform.localScale;
                    if (s.x > 0) s.x *= -1;
                    transform.localScale = s;
                }
                else
                {
                    Vector3 s = transform.localScale;
                    if (s.x < 0) s.x *= -1;
                    transform.localScale = s;
                }
            }
            //y成分が大きい場合
            else
            {
                if (!isUp)
                {
                    _animator.SetBool(_animParam_MoveUp, true);
                    if (isRight)
                    {
                        Vector3 s = transform.localScale;
                        if (s.x > 0) s.x *= -1;
                        transform.localScale = s;
                    }
                    else
                    {
                        Vector3 s = transform.localScale;
                        if (s.x < 0) s.x *= -1;
                        transform.localScale = s;
                    }
                }
                else
                {
                    _animator.SetBool(_animParam_MoveDown, true);
                    if (isRight)
                    {
                        Vector3 s = transform.localScale;
                        if (s.x > 0) s.x *= -1;
                        transform.localScale = s;
                    }
                    else
                    {
                        Vector3 s = transform.localScale;
                        if (s.x < 0) s.x *= -1;
                        transform.localScale = s;
                    }
                }
            }
        }
    }

    protected void SetAnimParamAllFalse()
    {
        _animator.SetBool(_animParam_MoveUp, false);
        _animator.SetBool(_animParam_MoveDown, false);
        _animator.SetBool(_animParam_MoveBeside, false);
    }
}
