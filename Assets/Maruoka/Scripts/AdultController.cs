using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �ړ���������l����R���|�[�l���g </summary>
public class AdultController : MonoBehaviour
{
    public bool _isSurprised = false;
    bool _isBeforeSurprised = false;
    /// <summary> �����̃g�����X�t�H�[�� </summary>
    Transform _entrancePos;
    /// <summary> �����I�u�W�F�N�g�̃^�O </summary>
    [Header("�����I�u�W�F�N�g�̃^�O"), SerializeField] string _entranceTagName = "StartObject";

    /// <summary> �����̃g�����X�t�H�[�� </summary>
    Transform _childPos;
    /// <summary> �����I�u�W�F�N�g�̃^�O </summary>
    [Header("�q���̃^�O"), SerializeField] string _childTagName = "Child";

    [Header("�A�ꋎ�鎞�̋���"), SerializeField] float _distanceToTakeAway;

    [Header("��l����������ď�����܂ł̎���"), SerializeField] float _isTimeToDisappear;

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
            //�����ɋ��������̏������L�q����B
            //�����Ɍ������đ���
            GetComponent<NPCMove>().ChangeFollowObject(_entrancePos);
            //���΂炭�҂��ď��ł���B
            Destroy(gameObject, _isTimeToDisappear);

        }
        _isBeforeSurprised = _isSurprised;
    }

    /// <summary> _isSurprised�ϐ��̕ω������m����B </summary>
    /// <returns> �ω������t���[���̂� true ��Ԃ��B </returns>
    public bool GetChanged_isSurprised()
    {
        return _isBeforeSurprised != _isSurprised;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // �����Ă��炸�A�q���ɐڐG���Ă����
        if (collision.gameObject.tag == _childTagName && !GetChanged_isSurprised())
        {
            //�����Ɍ������đ���
            GetComponent<NPCMove>().ChangeFollowObject(_entrancePos);
        }
    }
}
