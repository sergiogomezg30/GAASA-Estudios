using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coche : MonoBehaviour
{
    public int carHP = 10;
    public Slider slider;
    public Animator shakeOnHit;
    public Animator loseShake;
    public ParticleSystem explosion;
    public AudioClip choque;
    public GameObject sonidoFinal;

    private float timeElapsed = 0;
    public GameObject[] objetos;
    [SerializeField]
    private float manadaJabalies = 90;
    private AudioSource audioSource;

    [SerializeField] private FinalDiaSystem finalDia;

    void Start(){
        audioSource = GetComponent<AudioSource>();
        sonidoFinal.SetActive(false);
    }

    void Update()
    {
        slider.value = timeElapsed;
        timeElapsed += Time.deltaTime;

        if (carHP <=0)
        {
            //audioSource.PlayOneShot(choque); BUSCAR COMO HACER QUE SUENE
            StartCoroutine(EndMinigame());
            //loseShake.SetTrigger("loseShake");
            //Instantiate(explosion, transform.position, Quaternion.identity);
            //Destroy(gameObject);

        }


        //Si el jugador ha sobrevivido durante al menos 1 minuto y medio, una manada de jabalies entorpecera el paso
        if (timeElapsed >= manadaJabalies)
        {
            objetos[0].SetActive(true);
            objetos[1].SetActive(true);
        }

        //Control de dialogos segun tiempo transcurrido

        if (timeElapsed >= 2)
        {
            objetos[2].SetActive(true);
        }

        if (timeElapsed >= 6)
        {
            objetos[2].SetActive(false);
            objetos[3].SetActive(true);
        }

        if (timeElapsed >= 10)
        {
            objetos[3].SetActive(false);
        }


    }

    IEnumerator EndMinigame()
    {
        Debug.Log("kkhuete");

        yield return new WaitForSeconds(0.5f);
        Debug.Log("despues del wait");

        //finalDia.ShowFinalDayUI();

        loseShake.SetTrigger("loseShake");
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        sonidoFinal.SetActive(true);
        
    }

    public void Shake()
    {
        shakeOnHit.SetTrigger("shake");
    }
}
