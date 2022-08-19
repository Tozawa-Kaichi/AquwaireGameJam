using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 子供が画面外に出た時に方向を指し示すスクリプト
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

        // （画面中心を原点(0,0)とした）ターゲットのスクリーン座標を求める
        var pos = mainCamera.WorldToScreenPoint(target.position) - center;

        rectTransform.anchoredPosition = pos;
    }
}
