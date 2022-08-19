using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �A�j���[�V�����J�ڂ̃R���g���[���[ </summary>
public class AnimationTransitionController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    protected Animator _animator;

    [Header("�A�j���[�V�����p�����[�^�̖��O : �A�C�h��"), SerializeField] string _animParam_idle = "IsIdle";
    [Header("�A�j���[�V�����p�����[�^�̖��O : �E�ֈړ����Ă��邩"), SerializeField] string _animParam_MoveBeside = "IsMoveBeside";
    [Header("�A�j���[�V�����p�����[�^�̖��O : ��ֈړ����Ă��邩"), SerializeField] string _animParam_MoveUp = "IsMoveUp";
    [Header("�A�j���[�V�����p�����[�^�̖��O : ���ֈړ����Ă��邩"), SerializeField] string _animParam_MoveDown = "IsMoveDown";

    [Header("�A�j���[�V�����p�����[�^�̖��O : ���ֈړ����Ă��邩"), SerializeField] protected string _animParamName_AnimSpeed = "AnimSpeed";

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
            //���E�𔻒�
            if (_rigidbody2D.velocity.x > 0f)
            {
                isRight = true;
            }
            else
            {
                isRight = false;
            }
            //�㉺�𔻒�
            if (_rigidbody2D.velocity.y > 0f)
            {
                isUp = true;
            }
            else
            {
                isUp = false;
            }

            //�ǂ����̐������傫�������肵�p�����[�^��ύX����
            //x�������傫���ꍇ ���E���؂�Ԃ�
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
            //y�������傫���ꍇ
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
