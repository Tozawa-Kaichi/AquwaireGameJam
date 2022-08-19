using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 移動を除く 子供操作コンポーネント </summary>
public class ChildController : MonoBehaviour
{
    /// <summary> 連れ去られているかどうか </summary>
    public bool _isBeTakenAway = false;
    Transform _adultPos;
    [Header("大人オブジェクトのタグ"), SerializeField] string _adultTagName = "Adult";
    [Header("ゴーストのトランスフォーム"), SerializeField] Transform _ghost;
    [Header("入口のトランスフォーム"), SerializeField] Transform _entrancePos;
    [SerializeField] GameObject _beatUI;
    void Start()
    {
        //_adultPos = GameObject.FindGameObjectWithTag(_adultTagName).transform;
    }

    void Update()
    {
        //連れ去られていないときの処理
        if (!_isBeTakenAway)
        {
            GetComponent<NPCMove>().ChangeFollowObject(_ghost);
            GetComponent<NPCMove>()._isMove = Input.GetButton("Fire1");
            _beatUI.SetActive(false);
            BgmManager.RestVolume();
        }
        //連れ去られる時の処理
        else
        {
            _beatUI.SetActive(true);
            BgmManager.SetVolume(0.1f);
            GetComponent<NPCMove>()._isMove = true;
            GetComponent<NPCMove>().ChangeFollowObject(_entrancePos);
        }

        if (_adultPos != null && _adultPos.gameObject.GetComponent<AdultController>().GetChanged_isSurprised())
        {
            _isBeTakenAway = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _adultTagName)
        {
            _adultPos = collision.transform;
            _isBeTakenAway = true;
        }
    }
}
