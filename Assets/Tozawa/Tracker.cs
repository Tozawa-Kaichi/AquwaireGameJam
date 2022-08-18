using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tracker : MonoBehaviour
{
    [Tooltip("子供の位置"), SerializeField]
    Transform _targetTransform = default;
    [Tooltip("このシーンのカメラ"), SerializeField]
    Camera _thisSceneCamera = default;
    [Tooltip("画面外にいることを示すアイコン"), SerializeField]
    Image _directionIcon = default;//UIImageを参照してね

    private Rect _rect = new Rect(0, 0, 1, 1);//画面
    private Rect _canvasRect = default;//UIの画面

    private void Start()
    {
        // UIがはみ出ないようにする
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
            // 画面内で対象を追跡
            viewport.x = Mathf.Clamp01(viewport.x);
            viewport.y = Mathf.Clamp01(viewport.y);
            _directionIcon.rectTransform.anchoredPosition = Rect.NormalizedToPoint(_canvasRect, viewport);
        }
    }
}
