using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーアニメーションの種類
/// </summary>
public enum PlayerAnimationType
{
    Down = 0,
    Up = 1,
    Right = 2,
    Left = 3,

    ScaringDown = 100,
    ScaringUp = 101,
    ScaringRight = 102,
    ScaringLeft = 103,

    InvitingDown = 200,
    InvitingUp = 201,
    InvitingRight = 202,
    InvitingLeft = 203
}

/// <summary>
/// プレイヤーのアニメーターを更新するもの
/// </summary>
public class PlayerAnimatorUpdater : AnimatorUpdater
{
    /// <summary>
    /// 怖がらせるアニメーションIDのオフセット
    /// </summary>
    public static readonly int ScaringIdOffset = 100;

    /// <summary>
    /// 招くアニメーションIDのオフセット
    /// </summary>
    public static readonly int InvitingIdOffset = 200;

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    PlayerMove _playerMove = null;

    /// <summary>
    /// 周囲を怖がらせるオブジェクト
    /// </summary>
    Scaring _player = null;

    protected override void Awake()
    {
        base.Awake();

        _playerMove = GetComponent<PlayerMove>();
        _player = GetComponentInChildren<Scaring>(true);
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();

        UpdateParameters(_playerMove.LastInputMoveDirection, _player.IsScaring(), _player.IsInviting);
    }

    /// <summary>
    /// アニメーターのパラメーターを更新する
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="isScaring"></param>
    public void UpdateParameters(Vector2 direction, bool isScaring, bool isInviting)
    {
        PlayerAnimationType type = PlayerAnimationType.Down;
        if (direction.y > 0.0f)
        {
            type = PlayerAnimationType.Up;
        }
        else if (direction.x > 0.0f)
        {
            type = PlayerAnimationType.Right;
        }
        else if (direction.x < 0.0f)
        {
            type = PlayerAnimationType.Left;
        }

        if (isScaring)
        {
            type += ScaringIdOffset;
        }
        else if(isInviting)
        {
            type += InvitingIdOffset;
        }

        _animator.SetInteger("Id", (int)type);
    }
}
