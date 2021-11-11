using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsHandler : MonoBehaviour
{
    [SerializeField] private controlPersonaje player;
    private Vector3 targetPosition;

    private Camera cam;
    private Interactable actualInteraction;

    [HideInInspector] public bool isInAnInteraction;

    void Start()
    {
        isInAnInteraction = false;
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (!isInAnInteraction && Physics.Raycast(ray, out RaycastHit hitInfo)) {
                targetPosition = hitInfo.point;
                actualInteraction = hitInfo.collider.gameObject.GetComponent<Interactable>();

                if (actualInteraction != null) {
                    if (actualInteraction.GetTriggerCollider().bounds.Intersects(player.GetComponent<BoxCollider>().bounds)) {
                        StartInteraction();
                    }
                    else { 
                        player.SetTarget(targetPosition);
                    }
                }
            }
        }
    }

    public Interactable GetActualInteraction()
    {
        return actualInteraction;
    }
    public void NullifyActualInteraction()
    {
        actualInteraction = null;
    }

    public void StartInteraction()
    {
        isInAnInteraction = true;

        player.canMove = false;  //desactivar control personaje hasta que se acabe de interactuar

        actualInteraction.GetPhysicalCollider().enabled = true; //puedes chocarte solamente cuando vas hacia ello, si no lo atraviesas
        actualInteraction.Interact();
    }
    public void InteractionFinished()
    {
        player.canMove = true;

        actualInteraction.GetPhysicalCollider().enabled = false;

        isInAnInteraction = false;
        actualInteraction = null;
    }
}
