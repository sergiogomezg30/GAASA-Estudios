using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HaciaMinijuego : Interactable
{

    [SerializeField] private string sceneName;

    private void Start()
    {
        StartInteractable();
    }

    public override string GetDescription()
    {
        return "I am going to send you to the " + sceneName;
    }

    public override void Interact()
    {

        Debug.Log("Hacia la escena " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
