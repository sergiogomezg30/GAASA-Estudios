using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : Interactable
{
    [SerializeField] private GameObject playerGO;
    [SerializeField] private Transform destino;
    public Animator fundidoNegro;
    

    public override string GetDescription()
    {
        return "Soy una puerta que te lleva a un lugar llamado: " + destino;
    }

    public override void Interact()
    {
        StartCoroutine(Teletransport());
    }

    private void Start()
    {
        StartInteractable();
    }
    
    /// <summary>
    /// Lo he hecho coroutina para que 
    /// puedas trastear con el tiempo de la animacion sin Timeline
    /// </summary>
    IEnumerator Teletransport()
    {
        

        fundidoNegro.SetTrigger("transicion");
        yield return new WaitForSeconds(0.5f);  //el tiempo se puede cambiar, es para que de tiempo a ejecutarse el codigo

        player.SetTarget(destino.position);
        playerGO.transform.position = destino.position;

        interactionsHandler.InteractionFinished();  //lo pongo aquí ya que no hay ningun evento que lo haga acabar

        yield return null;
    }
}
