using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildAnimationTransitionController : AnimationTransitionController
{
    ChildController _childController;
    [Header("アニメーションパラメータの名前 : 連れ去られる状態"), SerializeField] string _animParam_taken = "IsTaken";

    protected override void Start()
    {
        base.Start();
        _childController = GetComponent<ChildController>();
    }

    protected override void Update()
    {
        if (_childController._isBeTakenAway)
        {
            _animator.SetBool(_animParam_taken, true);
        }
        else
        {
            base.Update();
            _animator.SetBool(_animParam_taken, false);
        }
    }
}
