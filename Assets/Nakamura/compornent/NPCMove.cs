using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class NPCMove : MonoBehaviour
{
    /// <summary>NPC���ړ��ł��邩 /// </summary>
    [Header("�ړ��\���ۂ�"), SerializeField] public bool _isMove = true;
    /// <summary>NPC�̈ړ����x/// </summary>
    [Header("NPC�̈ړ����x"), SerializeField] float _moveSpeed = 5;
    /// <summary>object�̃f�[�^������Ă���i���position�j/// </summary>
    [Header("�ǔ���̃I�u�W�F�N�g"),SerializeField] Transform _followObject;
    Rigidbody2D _rb2d;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (_isMove)
        {
            Vector3 _move = (_followObject.transform.position - this.transform.position).normalized * _moveSpeed;
            _rb2d.velocity = _move;
        }
        else
        {
            _rb2d.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isMove = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isMove = true;
    }
    public void ChangeFollowObject(Transform newFllowObject)
    {
        _followObject = newFllowObject;
    }
}
