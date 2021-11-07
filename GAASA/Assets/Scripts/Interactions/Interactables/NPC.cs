using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    [SerializeField] private string nameNPC;
    [SerializeField] private string[] dialogueNPC;

    [SerializeField] private InteractionsHandler interactionsHandler;

    private void Start()
    {
        StartNPC();
    }

    private void StartNPC()
    {
        hasInteracted = false;
        interactionType = InteractionType.Click;
        Debug.Log(gameObject.GetComponent<SpriteRenderer>().sprite != null);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("kk de vaca");
        if (interactionsHandler.GetActualInteraction() == this) {
            interactionsHandler.StartInteraction();
            player.SetTarget(player.transform.position);    //para que el personaje no haga el intento de seguir avanzando
        }
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
