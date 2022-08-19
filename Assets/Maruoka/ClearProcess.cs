using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Clearèàóù
/// </summary>
public class ClearProcess : MonoBehaviour
{
    [SerializeField] string _clearSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Child")
        {
            SceneManager.LoadScene(_clearSceneName);
        }
    }
}
