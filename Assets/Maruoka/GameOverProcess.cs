using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverProcess : MonoBehaviour
{
    [SerializeField] string _gameOverSceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Child")
        {
            SceneManager.LoadScene(_gameOverSceneName);
        }
    }
}
