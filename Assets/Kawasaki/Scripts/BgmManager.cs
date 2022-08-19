using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BGMの管理者
/// </summary>
public class BgmManager : MonoBehaviour
{
    public static BgmManager Current = null;

    AudioSource _audioSource = null;

    float initialVolume = 0.0f;

    private void Awake()
    {
        Current = this;

        _audioSource = GetComponent<AudioSource>();
        initialVolume = _audioSource.volume;
    }

    /// <summary>
    /// 音量を設定する(Awakeでは使用しないこと)
    /// </summary>
    /// <param name="value">音量</param>
    public static void SetVolume(float value)
    {
        Current._audioSource.volume = value;
    }

    /// <summary>
    /// 音量をリセットする(Awakeでは使用しないこと)
    /// </summary>
    public static void RestVolume()
    {
        Current._audioSource.volume = Current.initialVolume;
    }
}
