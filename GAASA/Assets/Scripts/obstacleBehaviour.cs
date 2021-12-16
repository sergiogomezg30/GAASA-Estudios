using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBehaviour : MonoBehaviour
{
    public int dmg = 1;
    public float spd;
   
    // Update is called once per frame
    void Update()
    {
        //El obstaculo se mueve a la izquierda para simular el movimientp del jugador
        transform.Translate(Vector2.left * spd * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        coche controller = other.GetComponent<coche>();

        if (other.CompareTag("Coche"))
        {
            //Buscar el componente coche que almacena la vida del coche y restarle el dmg
            other.GetComponent<coche>().carHP -= dmg;
            other.GetComponent<coche>().Shake();
            Debug.Log("El coche ha sufrido da�o");
            Destroy(gameObject);
            controller.PlaySound();
        }

        if (other.CompareTag("Collider"))
        {
            //Evitamos saturar la escena
            Destroy(gameObject);
        }

    }
}
