using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultController : MonoBehaviour
{
    public bool _isSurprised = false;
    bool _isBeforeSurprised = false;

    void Start()
    {

    }

    void Update()
    {
        Changed_isSurprised();
        _isBeforeSurprised = _isSurprised;
    }

    bool Changed_isSurprised()
    {
        return _isBeforeSurprised != _isSurprised;
    }
}
