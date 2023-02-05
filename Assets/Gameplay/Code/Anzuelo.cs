using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anzuelo : MonoBehaviour
{
    public AudioClip collectSoundEffect;
    public float timeToLive = 5;
    float tiempoTranscurrido;

    // Start is called before the first frame update
    void Start()
    {

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
            collision.GetComponent<AudioSource>().clip = collectSoundEffect;
            collision.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
