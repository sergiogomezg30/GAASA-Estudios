using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    [SerializeField] private string nameNPC;
    [SerializeField] private string[] dialogueNPC;

    private void Start()
    {
        StartNPC();
    }

    private void StartNPC()
    {
        hasInteracted = false;
        interactionType = InteractionType.Click;
    }

    public override string GetDescription()
    {
        return "Click me to Talk!";
    }

    public override InteractionType GetInteractionType()
    {
        return interactionType;
    }

    public override void Interact()
    {
        Debug.Log("I am " + nameNPC + " and I have " + dialogueNPC.Length + "sentences");
    }
}
