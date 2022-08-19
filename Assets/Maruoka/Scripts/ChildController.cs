using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �ړ������� �q������R���|�[�l���g </summary>
public class ChildController : MonoBehaviour
{
    /// <summary> �A�ꋎ���Ă��邩�ǂ��� </summary>
    public bool _isBeTakenAway = false;
    Transform _adultPos;
    [Header("��l�I�u�W�F�N�g�̃^�O"), SerializeField] string _adultTagName = "Adult";
    [Header("�S�[�X�g�̃g�����X�t�H�[��"), SerializeField] Transform _ghost;
    [Header("�����̃g�����X�t�H�[��"), SerializeField] Transform _entrancePos;
    [SerializeField] GameObject _beatUI;
    void Start()
    {
        //_adultPos = GameObject.FindGameObjectWithTag(_adultTagName).transform;
    }

    void Update()
    {
        //�A�ꋎ���Ă��Ȃ��Ƃ��̏���
        if (!_isBeTakenAway)
        {
            GetComponent<NPCMove>().ChangeFollowObject(_ghost);
            GetComponent<NPCMove>()._isMove = Input.GetButton("Fire1");
            _beatUI.SetActive(false);
            BgmManager.RestVolume();
        }
        //�A�ꋎ���鎞�̏���
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
