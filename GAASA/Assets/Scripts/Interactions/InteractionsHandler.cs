using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsHandler : MonoBehaviour
{
    private Camera cam;
    private Interactable actualInteraction;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo)) {
                actualInteraction = hitInfo.collider.gameObject.GetComponent<Interactable>();
                if (actualInteraction != null) {
                    actualInteraction.Interact();
                }
            }
        }
    }
}
