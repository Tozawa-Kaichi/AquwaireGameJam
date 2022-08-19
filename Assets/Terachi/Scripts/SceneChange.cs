using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

   public  GameObject gameExplain;


    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif  
    }

    public void GoGameExplain()
    {
        gameExplain.SetActive(true);
    }

    public void ExitGameExplain()
    {
        gameExplain.SetActive(false);

    }

    public void GoTitle()
    {
        //SceneManager.LoadScene("Title");
        Debug.Log("タイトル押された");
    }
}
