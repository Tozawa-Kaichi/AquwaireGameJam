using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

   public  GameObject gameExplain;


    public void GoPlayScene()
    {
        //SceneManager.LoadScene("");
        Debug.Log("playScene�Ă΂ꂽ");

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
}
