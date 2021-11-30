using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPersonaje : MonoBehaviour
{

    public float speed;
    public bool canMove;

    Vector3 target;

    [SerializeField] private InteractionsHandler interactionsHandler;

    
    void Start()
    {
        canMove = true;
        target = transform.position;
    }
    
    void LateUpdate()
    {
        if(Input.GetMouseButtonDown(0) && canMove){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo)) {
                if (hitInfo.collider.gameObject.CompareTag("suelo")) {
                    target = hitInfo.point;
                }
            }

                //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //target.z = 0f;
            if (interactionsHandler != null) {
                if (interactionsHandler.GetActualInteraction() != null && !interactionsHandler.GetActualInteraction().GetTriggerCollider().bounds.Contains(target)) {
                    interactionsHandler.NullifyActualInteraction();
                }
            }
            else {
                Debug.LogWarning("No hay interactionHandler, ¿ES A DREDE?");
            }
            
        }
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.CompareTag("cielo"))
        {
            target = transform.position;
        }
    }

    public void SetTarget(Vector3 newTarget)
    {
        target = new Vector3(newTarget.x, newTarget.y, 0);  //la z a 0 siempre :)
    }
}
