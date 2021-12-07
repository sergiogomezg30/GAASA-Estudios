using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ESTE CODIGO NO DEBE ESTAR ATADA A NINGUN OBJETO
/// sirve como base para el resto de codigos que hereden de aquí
/// como NPC o HaciaMinijuego...
/// 
/// TODAS LAS CLASES HEREDADAS DEBEN TENER EN EL START LA FUNCION STARTINTERACTABLE()
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        Click
    }

    [SerializeField] protected BoxCollider physicalCollider;
    [SerializeField] protected BoxCollider triggerCollider;

    protected controlPersonaje player;
    protected InteractionsHandler interactionsHandler;

    protected InteractionType interactionType;
    [HideInInspector] public bool hasInteracted;

    ////////////Abstract methods////////////
    public abstract string GetDescription();
    public abstract void Interact();
    ////////////////////////////////////////


    /////////////Regular methods////////////
    //privates
    private void OnTriggerEnter(Collider other)
    {
        if (interactionsHandler.GetActualInteraction() == this)
        {
            interactionsHandler.StartInteraction();
            player.SetTarget(player.transform.position);    //para que el personaje no haga el intento de seguir avanzando
        }
    }

    //protecteds
    protected virtual void StartInteractable()  //this method must be called in the Start Unity functions
    {
        hasInteracted = false;
        interactionType = InteractionType.Click;

        interactionsHandler = GameObject.Find("Main Camera").GetComponent<InteractionsHandler>();
        player = GameObject.Find("Player").GetComponent<controlPersonaje>();
    }

    //publics
    public InteractionType GetInteractionType()
    {
        return interactionType;
    }

    public BoxCollider GetPhysicalCollider()
    {
        return physicalCollider;
    }
    public BoxCollider GetTriggerCollider()
    {
        return triggerCollider;
    }
    ////////////////////////////////////////
}
