using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static string sceneToLoad;
    public static string SceneToLoad { get => sceneToLoad;}
    public static void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public static void ProgressLoad(string sceneName)
    {
        sceneToLoad = sceneName;
        SceneManager.LoadScene("LoadingProgress");
    }
}
