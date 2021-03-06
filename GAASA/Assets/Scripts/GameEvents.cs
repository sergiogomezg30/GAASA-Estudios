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

    public event Action<string> onFinishDialogue;
    public void FinishDialogue(string npcName)
    {
        if (onFinishDialogue != null) {
            onFinishDialogue(npcName);
        }
    }

    public event Action onDoorExit;
    public void DoorExit()
    {
        if (onDoorExit != null) {
            onDoorExit();
        }
    }
}
