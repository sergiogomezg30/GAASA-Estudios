using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motorAnimaciónInicio : MonoBehaviour
{
    public GameObject motor;
    public GameObject menu;
    
    void Start()
    {
        motor.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(menu.activeSelf == true){
            motor.SetActive(false);
        }
    }
}
