using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �A�j���[�V�����J�ڂ̃R���g���[���[ </summary>
public class AnimationTransitionController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    Animator _animator;

    [Header("�A�j���[�V�����p�����[�^�̖��O : �A�C�h��"), SerializeField] string _animParam_idle = "IsIdele";
    [Header("�A�j���[�V�����p�����[�^�̖��O : �E�ֈړ����Ă��邩"), SerializeField] string _animParam_MoveRight = "IsMoveRight";
    [Header("�A�j���[�V�����p�����[�^�̖��O : ���ֈړ����Ă��邩"), SerializeField] string _animParam_MoveLeft = "IsMoveLeft";
    [Header("�A�j���[�V�����p�����[�^�̖��O : ��ֈړ����Ă��邩"), SerializeField] string _animParam_MoveUp = "IsMoveUp";
    [Header("�A�j���[�V�����p�����[�^�̖��O : ���ֈړ����Ă��邩"), SerializeField] string _animParam_MoveDown = "IsMoveDown";

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
        //��𔻒肷��
        else if (_rigidbody2D.velocity.y > 0)
        {
            _animator.SetBool(_animParam_MoveUp, true);
        }
        //���𔻒肷��
        else if (_rigidbody2D.velocity.y < 0)
        {
            _animator.SetBool(_animParam_MoveDown, true);
        }
        //�E�𔻒肷��
        else if (_rigidbody2D.velocity.x > 0)
        {
            _animator.SetBool(_animParam_MoveRight, true);
        }
        // ���𔻒肷��
        else�@if(_rigidbody2D.velocity.x < 0)
        {
            _animator.SetBool(_animParam_MoveLeft, true);
        }
    }
}
