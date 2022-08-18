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
    /// 速度
    /// </summary>
    [SerializeField]
    float _speed = 0.0f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
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
        Vector2 direction = new(horizontal, vertical);
        Vector2 velocity = _speed * Time.deltaTime * direction;

        _rigidbody2D.velocity = velocity;
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
