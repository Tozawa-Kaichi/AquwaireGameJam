using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 移動を除く大人操作コンポーネント </summary>
public class AdultController : MonoBehaviour
{
    public bool _isSurprised = false;
    bool _isBeforeSurprised = false;
    /// <summary> 入口のトランスフォーム </summary>
    Transform _entrancePos;
    /// <summary> 入口オブジェクトのタグ </summary>
    [Header("入口オブジェクトのタグ"), SerializeField] string _entranceTagName = "StartObject";

    /// <summary> 入口のトランスフォーム </summary>
    Transform _childPos;
    /// <summary> 入口オブジェクトのタグ </summary>
    [Header("子供のタグ"), SerializeField] string _childTagName = "Child";

    [Header("連れ去る時の距離"), SerializeField] float _distanceToTakeAway;

    [Header("大人が驚かされて消えるまでの時間"), SerializeField] float _isTimeToDisappear;

    void Start()
    {
        _entrancePos = GameObject.FindGameObjectWithTag(_entranceTagName).transform;
        _childPos = GameObject.FindGameObjectWithTag(_childTagName).transform;

        GetComponent<NPCMove>().ChangeFollowObject(_childPos);
    }

    void Update()
    {
        if (GetChanged_isSurprised())
        {
            //ここに驚いた時の処理を記述する。
            //入口に向かって走る
            GetComponent<NPCMove>().ChangeFollowObject(_entrancePos);
            //しばらく待って消滅する。
            Destroy(gameObject, _isTimeToDisappear);

        }
        _isBeforeSurprised = _isSurprised;
    }

    /// <summary> _isSurprised変数の変化を検知する。 </summary>
    /// <returns> 変化したフレームのみ true を返す。 </returns>
    public bool GetChanged_isSurprised()
    {
        return _isBeforeSurprised != _isSurprised;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // 驚いておらず、子供に接触していれば
        if (collision.gameObject.tag == _childTagName && !GetChanged_isSurprised())
        {
            //入口に向かって走る
            GetComponent<NPCMove>().ChangeFollowObject(_entrancePos);
        }
    }
}
