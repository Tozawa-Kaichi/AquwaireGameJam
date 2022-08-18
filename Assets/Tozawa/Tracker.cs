using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tracker : MonoBehaviour
{
    [Tooltip("�q���̈ʒu"), SerializeField]
    Transform _targetTransform = default;
    [Tooltip("���̃V�[���̃J����"), SerializeField]
    Camera _thisSceneCamera = default;
    [Tooltip("��ʊO�ɂ��邱�Ƃ������A�C�R��"), SerializeField]
    Image _directionIcon = default;//UIImage���Q�Ƃ��Ă�

    private Rect _rect = new Rect(0, 0, 1, 1);//���
    private Rect _canvasRect = default;//UI�̉��

    private void Start()
    {
        // UI���͂ݏo�Ȃ��悤�ɂ���
        _canvasRect = ((RectTransform)_directionIcon.canvas.transform).rect;
        _canvasRect.Set(
            _canvasRect.x + _directionIcon.rectTransform.rect.width * 0.5f,
            _canvasRect.y + _directionIcon.rectTransform.rect.height * 0.5f,
            _canvasRect.width - _directionIcon.rectTransform.rect.width,
            _canvasRect.height - _directionIcon.rectTransform.rect.height);
    }
    private void Update()
    {
        var viewport = _thisSceneCamera.WorldToViewportPoint(_targetTransform.position);
        if (_rect.Contains(viewport))
        {
            _directionIcon.enabled = false;
        }
        else
        {
            _directionIcon.enabled = true;
            // ��ʓ��őΏۂ�ǐ�
            viewport.x = Mathf.Clamp01(viewport.x);
            viewport.y = Mathf.Clamp01(viewport.y);
            _directionIcon.rectTransform.anchoredPosition = Rect.NormalizedToPoint(_canvasRect, viewport);
        }
    }
}
