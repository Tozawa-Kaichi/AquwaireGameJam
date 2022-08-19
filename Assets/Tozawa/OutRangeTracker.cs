using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �q������ʊO�ɏo�����ɕ������w�������X�N���v�g
/// </summary>
public class OutRangeTracker : MonoBehaviour
{
    [SerializeField]
    private Transform target = default;

    private Camera mainCamera;
    private RectTransform rectTransform;

    private void Start()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        var center = 0.5f * new Vector3(Screen.width, Screen.height);

        // �i��ʒ��S�����_(0,0)�Ƃ����j�^�[�Q�b�g�̃X�N���[�����W�����߂�
        var pos = mainCamera.WorldToScreenPoint(target.position) - center;

        rectTransform.anchoredPosition = pos;
    }
}
