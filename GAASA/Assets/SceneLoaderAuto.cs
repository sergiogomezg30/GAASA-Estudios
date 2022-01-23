using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoaderAuto : MonoBehaviour
{
    public string SceneName;

    void OnEnable()
    {
        SceneManager.LoadScene(SceneName);
    }
}
