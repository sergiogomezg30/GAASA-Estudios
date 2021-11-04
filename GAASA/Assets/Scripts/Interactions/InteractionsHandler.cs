using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsHandler : MonoBehaviour
{
    private Camera cam;
    private Interactable actualInteraction;

    public bool isInAnInteraction;

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
                actualInteraction = hitInfo.collider.gameObject.GetComponent<Interactable>();
                if (actualInteraction != null) {
                    actualInteraction.Interact();
                    isInAnInteraction = true;
                }
            }
        }
    }
}
