using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;

public class controlPersonaje : MonoBehaviour, IDondeMiro
{
    public enum MiembroFamiliar
    {
        Madre,
        Abuelo,
        Nino,
        Padre
    }

    public float speed;
    public bool canMove;
    public MiembroFamiliar familiarQueSoy;
    //public GameObject animPersonaje;

    Vector3 target;
    [SerializeField] private RuntimeAnimatorController[] personajesAnimator;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private InteractionsHandler interactionsHandler;

    [SerializeField]private bool _originImageMirandoDer;
    public bool originImageMirandoDer { get => _originImageMirandoDer;}

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        canMove = true;
        target = transform.position;

        //para saber que personaje animar reciclando el codigo
        switch (familiarQueSoy)
        {
            case MiembroFamiliar.Madre:
                animator.runtimeAnimatorController = personajesAnimator[0];
                break;
            case MiembroFamiliar.Abuelo:
                animator.runtimeAnimatorController = personajesAnimator[1];
                transform.localScale = new Vector3(2.5f * 0.4f, 2.5f * 0.4f, 1f);   //es la escala que puso gonzalo en Dia2 que la he copiado
                break;
            case MiembroFamiliar.Nino:
                animator.runtimeAnimatorController = personajesAnimator[2];
                transform.localScale = new Vector3(0.7f, 0.7f, 1f);   //es la escala que puso gonzalo en Dia2 que la he copiado
                break;
            //case MiembroFamiliar.Padre:
                //animator.runtimeAnimatorController = personajesAnimator[3];
                //break;
            default:
                Debug.LogError("Algo va mal con los animator del personaje");
                break;
        }
    }
    
    void LateUpdate()
    {
        if(Input.GetMouseButtonDown(0) && canMove){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo)) {
                if (hitInfo.collider.gameObject.CompareTag("suelo")) {
                    //target = hitInfo.point;
                    SetTarget(hitInfo.point);
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

        //cambiar animacion
        
        if (target.x < transform.position.x) {
            animator.SetBool("isMoving", true);

            if (!originImageMirandoDer)
                spriteRenderer.flipX = false;
            else
                spriteRenderer.flipX = true;
        }
        else if (target.x > transform.position.x){
            animator.SetBool("isMoving", true);

            if (!originImageMirandoDer)
                spriteRenderer.flipX = true;
            else
                spriteRenderer.flipX = false;
        }
        else {
            animator.SetBool("isMoving", false);
        }
    }

    void FixedUpdate()
    {
        //FlipSprite, esta guapisimo para hacer el michael jackson
        /*if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < animPersonaje.transform.position.x)
        {
            animPersonaje.transform.localScale = new Vector3(-1, 1, 1);
        }

        else
        {
            animPersonaje.transform.localScale = new Vector3(1, 1, 1);
        }*/

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
