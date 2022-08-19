using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> アニメーション遷移のコントローラー </summary>
public class AnimationTransitionController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    protected Animator _animator;

    [Header("アニメーションパラメータの名前 : アイドル"), SerializeField] string _animParam_idle = "IsIdele";
    [Header("アニメーションパラメータの名前 : 右へ移動しているか"), SerializeField] string _animParam_MoveRight = "IsMoveRight";
    [Header("アニメーションパラメータの名前 : 左へ移動しているか"), SerializeField] string _animParam_MoveLeft = "IsMoveLeft";
    [Header("アニメーションパラメータの名前 : 上へ移動しているか"), SerializeField] string _animParam_MoveUp = "IsMoveUp";
    [Header("アニメーションパラメータの名前 : 下へ移動しているか"), SerializeField] string _animParam_MoveDown = "IsMoveDown";

    protected virtual void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        _animator.SetBool(_animParam_idle, false);
        _animator.SetBool(_animParam_MoveUp, false);
        _animator.SetBool(_animParam_MoveDown, false);
        _animator.SetBool(_animParam_MoveRight, false);
        _animator.SetBool(_animParam_MoveLeft, false);

        bool isRight;
        bool isUp;

        if (_rigidbody2D.velocity == Vector2.zero)
        {
            _animator.SetBool(_animParam_idle, true);
        }
        else
        {
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
            if (_rigidbody2D.velocity.x > _rigidbody2D.velocity.y)
            {
                if (isRight)
                {
                    Vector3 s = transform.localScale;
                    if (s.x < 0) s.x *= -1;
                    _animator.SetBool(_animParam_MoveRight, true);
                }
                else
                {
                    Vector3 s = transform.localScale;
                    if (s.x > 0) s.x *= -1;
                    _animator.SetBool(_animParam_MoveLeft, true);
                }
            }
            //y成分が大きい場合
            else
            {
                if (isUp)
                {
                    _animator.SetBool(_animParam_MoveUp, true);
                }
                else
                {
                    _animator.SetBool(_animParam_MoveDown, true);
                }
            }
        }
    }
}
