using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }
    }

    public event Action onFinishDialogue;
    public void FinishDialogue()
    {
        if (onFinishDialogue != null) {
            onFinishDialogue();
        }
    }
}
