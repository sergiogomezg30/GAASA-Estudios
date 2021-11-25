using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    [SerializeField] private string nameNPC;
    [SerializeField] private string[] dialogueNPC;

    private void Start()
    {
        StartInteractable();
    }

    public override string GetDescription()
    {
        return "Click me to Talk!";
    }

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogueNPC, nameNPC, gameObject.GetComponent<SpriteRenderer>());
        Debug.Log("I am " + nameNPC + " and I have " + dialogueNPC.Length + "sentences");
    }
}
