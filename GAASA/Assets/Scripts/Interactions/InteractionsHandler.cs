using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsHandler : MonoBehaviour
{
    [SerializeField] private controlPersonaje player;
    private Vector3 targetPosition;

    private Camera cam;
    private Interactable _actualInteraction;
    public Interactable actualInteraction { get => _actualInteraction; }

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
                _actualInteraction = hitInfo.collider.gameObject.GetComponent<Interactable>();

                if (_actualInteraction != null) {
                    if (_actualInteraction.GetTriggerCollider().bounds.Intersects(player.GetComponent<BoxCollider>().bounds)) {
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
        return _actualInteraction;
    }
    public void NullifyActualInteraction()
    {
        _actualInteraction = null;
    }

    public void StartInteraction()
    {
        isInAnInteraction = true;

        player.canMove = false;  //desactivar control personaje hasta que se acabe de interactuar

        _actualInteraction.GetPhysicalCollider().enabled = true; //puedes chocarte solamente cuando vas hacia ello, si no lo atraviesas
        _actualInteraction.Interact();
    }
    public void InteractionFinished()
    {
        player.canMove = true;

        _actualInteraction.GetPhysicalCollider().enabled = false;

        isInAnInteraction = false;
        _actualInteraction = null;
    }
}
