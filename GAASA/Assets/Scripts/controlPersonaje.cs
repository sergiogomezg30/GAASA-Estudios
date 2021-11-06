using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPersonaje : MonoBehaviour
{

    public float speed;
    Vector3 target;

    
    void Start()
    {
        target = transform.position;
    }
    
    void LateUpdate()
    {

        if(Input.GetMouseButtonDown(0)){
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0f;
        }
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.CompareTag("cielo"))
        {
            target = transform.position;
        }
    }
}
