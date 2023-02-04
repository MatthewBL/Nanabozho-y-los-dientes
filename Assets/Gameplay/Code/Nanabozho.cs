using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nanabozho : MonoBehaviour
{
    public float tiempoMinGiro = 0.1f;
    public float tiempoMaxGiro = 0.3f;

    public float tiempoVida = 10f;

    float tiempoGiro;

    Personaje personaje;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GetComponent<Personaje>();
        tiempoGiro = Random.Range(tiempoMinGiro, tiempoMaxGiro);
    }

    // Update is called once per frame
    void Update()
    {
        Animator animator = GetComponent<Animator>();

        tiempoGiro -= Time.deltaTime;
        tiempoVida -= Time.deltaTime;

        if (tiempoVida <= 0)
        {
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
