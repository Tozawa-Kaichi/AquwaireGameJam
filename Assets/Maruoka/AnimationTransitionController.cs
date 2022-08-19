using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �A�j���[�V�����J�ڂ̃R���g���[���[ </summary>
public class AnimationTransitionController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    protected Animator _animator;

    [Header("�A�j���[�V�����p�����[�^�̖��O : �A�C�h��"), SerializeField] string _animParam_idle = "IsIdele";
    [Header("�A�j���[�V�����p�����[�^�̖��O : �E�ֈړ����Ă��邩"), SerializeField] string _animParam_MoveRight = "IsMoveRight";
    [Header("�A�j���[�V�����p�����[�^�̖��O : ���ֈړ����Ă��邩"), SerializeField] string _animParam_MoveLeft = "IsMoveLeft";
    [Header("�A�j���[�V�����p�����[�^�̖��O : ��ֈړ����Ă��邩"), SerializeField] string _animParam_MoveUp = "IsMoveUp";
    [Header("�A�j���[�V�����p�����[�^�̖��O : ���ֈړ����Ă��邩"), SerializeField] string _animParam_MoveDown = "IsMoveDown";

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
            //y�������傫���ꍇ
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
