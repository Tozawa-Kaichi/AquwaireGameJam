using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCircleMove : MonoBehaviour
{
    bool _isMove = true;
    void Start()
    {
        
    }

    void Update()
    {
        if (_isMove)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isMove = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isMove = true;
    }
}
