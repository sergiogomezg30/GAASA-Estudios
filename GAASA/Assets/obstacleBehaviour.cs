using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBehaviour : MonoBehaviour
{
    public int dmg = 1;
    public float spd;
    [SerializeField]
    private int timeToDespawn = 5;

    //El objeto se autodestruye en n segundos para no saturar la escena
    void Star()
    {
        Destroy(gameObject, timeToDespawn);

    }
    // Update is called once per frame
    void Update()
    {
        //El obstaculo se mueve a la izquierda para simular el movimientp del jugador
        transform.Translate(Vector2.left * spd * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coche"))
        {
            //Buscar el componente coche que almacena la vida del coche y restarle el dmg
            other.GetComponent<coche>().carHP -= dmg;
            Debug.Log("El coche ha sufrido daño");
            Destroy(gameObject);
        } 
        
    }
}
