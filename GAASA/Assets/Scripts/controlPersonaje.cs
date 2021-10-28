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
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0f;
        }


        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
    }


}
