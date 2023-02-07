using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Nanabozho : NetworkBehaviour
{
    public float waitTime = 1f;

    public float tiempoMinGiro = 0.1f;
    public float tiempoMaxGiro = 0.3f;

    public float tiempoVida = 13f;

    float tiempoGiro;

    Personaje personaje;

    public AudioClip thunderClip;

    public AudioClip gameplayClip;
    public AudioClip nanabozhoClip;
    AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GetComponent<Personaje>();
        tiempoGiro = Random.Range(tiempoMinGiro, tiempoMaxGiro);
        GetComponent<AudioSource>().clip = thunderClip;
        GetComponent<AudioSource>().Play();
        music = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        music.clip = nanabozhoClip;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime >= 0)
        {
            personaje.multiplicadorVelocidad = 0;
        }
        else
        {
            personaje.multiplicadorVelocidad = 1;
            Animator animator = GetComponent<Animator>();

            tiempoGiro -= Time.deltaTime;
            tiempoVida -= Time.deltaTime;

            if (tiempoVida <= 0)
            {
                music.clip = gameplayClip;
                music.Play();
                Destroy(gameObject);
            }

            if (tiempoGiro <= 0)
            {
                tiempoGiro = Random.Range(tiempoMinGiro, tiempoMaxGiro);

                float directionX = Random.Range(0f, 1f);
                float directionY = Random.Range(0f, 1f);
                animator.SetInteger("Direccion", 1);
                if (transform.position.x > 0)
                {
                    directionX *= -1;
                    animator.SetInteger("Direccion", 0);
                }
                if (transform.position.y > 0)
                {
                    directionY *= -1;
                }

                personaje.SetDiagonalDirection(directionY, directionX);
            }
        }
    }
}
