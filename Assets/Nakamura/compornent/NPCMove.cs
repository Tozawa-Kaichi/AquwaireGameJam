using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class NPCMove : MonoBehaviour
{
    /// <summary>NPCが移動できるか /// </summary>
    [Header("移動可能か否か"), SerializeField] public bool _isMove = true;
    /// <summary>NPCの移動速度/// </summary>
    [Header("NPCの移動速度"), SerializeField] float _moveSpeed = 5;
    /// <summary>objectのデータを取ってくる（主にposition）/// </summary>
    [Header("追尾先のオブジェクト"),SerializeField] Transform _followObject;
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
