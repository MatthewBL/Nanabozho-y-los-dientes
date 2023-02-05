using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anzuelo : MonoBehaviour
{
    public AudioClip collectSoundEffect;
    public float timeToLive = 5;
    float tiempoTranscurrido;

    ContadorAnzuelos contadorAnzuelos;

    // Start is called before the first frame update
    void Start()
    {
        contadorAnzuelos = GameObject.FindGameObjectWithTag("ContadorAnzuelos").GetComponent<ContadorAnzuelos>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido >= timeToLive)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PersonajeControlable>())
        {
            contadorAnzuelos.anzuelosObtenidos += 1;
            collision.GetComponent<AudioSource>().clip = collectSoundEffect;
            collision.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
