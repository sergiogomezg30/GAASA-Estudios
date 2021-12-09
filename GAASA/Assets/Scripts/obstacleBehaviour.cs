using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBehaviour : MonoBehaviour
{
    public int dmg = 1;
    public float spd;
    public AudioClip golpe;

    private AudioSource audioSource; //Poner audioSource y el sonido del golpe a los objetos

    void Start(){
        audioSource = GetComponent<AudioSource>();
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
            other.GetComponent<coche>().Shake();
            audioSource.PlayOneShot(golpe);
            Debug.Log("El coche ha sufrido da�o");
            Destroy(gameObject);
        }

        if (other.CompareTag("Collider"))
        {
            //Evitamos saturar la escena
            Destroy(gameObject);
        }

    }
}
