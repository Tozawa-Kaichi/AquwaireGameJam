using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの移動
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// リジッドボディ2D
    /// </summary>
    Rigidbody2D _rigidbody2D = null;

    /// <summary>
    /// 向き
    /// </summary>
    Vector2 _direction = Vector2.down;

    /// <summary>
    /// 最後に入力した移動方向
    /// </summary>
    public Vector2 LastInputMoveDirection { get; private set; } = Vector2.zero;

    /// <summary>
    /// 速度
    /// </summary>
    [SerializeField]
    float _moveSpeed = 12.0f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();

        if (_direction != Vector2.zero)
        {
            LastInputMoveDirection = _direction;
        }
    }

    /// <summary>
    /// 移動する
    /// </summary>
    private void Move()
    {
        if (!CanMove())
        {
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _rigidbody2D.velocity = _moveSpeed * new Vector2(horizontal, vertical).normalized;
    }

    /// <summary>
    /// 移動可能である
    /// </summary>
    /// <returns></returns>
    private bool CanMove()
    {
        return true;
    }
}
