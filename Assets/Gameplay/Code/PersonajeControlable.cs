using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeControlable : MonoBehaviour
{
    public KeyCode arriba = KeyCode.W;
    public KeyCode derecha = KeyCode.D;
    public KeyCode abajo = KeyCode.S;
    public KeyCode izquierda = KeyCode.A;

    Personaje personaje;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GetComponent<Personaje>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlInput();
        UpdateAnimation();
    }

    void ControlInput()
    {
        Personaje.Orientation orientation = Personaje.Orientation.vertical;
        float direction = 0;
        if (Input.GetKey(arriba))
        {
            orientation = Personaje.Orientation.vertical;
            direction = 1;
        }
        if (Input.GetKey(derecha))
        {
            orientation = Personaje.Orientation.horizontal;
            direction = 1;
        }
        if (Input.GetKey(abajo))
        {
            orientation = Personaje.Orientation.vertical;
            direction = -1;
        }
        if (Input.GetKey(izquierda))
        {
            orientation = Personaje.Orientation.horizontal;
            direction = -1;
        }

        if (direction != 0)
        {
            personaje.SetDirection(orientation, direction);
        }
    }

    void UpdateAnimation()
    {
        float direccionHor = personaje.direccionHor;
        float direccionVert = personaje.direccionVert;
        if (!GetComponent<Animator>())
        {
            return;
        }
        if (Mathf.Abs(direccionVert) > Mathf.Abs(direccionHor))
        {
            if (direccionVert > 0)
            {
                GetComponent<Animator>().SetFloat("Direccion", 0);
            }
            else
            {
                GetComponent<Animator>().SetFloat("Direccion", 0.67f);
            }
        }
        else
        {
            if (direccionHor < 0)
            {
                GetComponent<Animator>().SetFloat("Direccion", 1);
            }
            else
            {
                GetComponent<Animator>().SetFloat("Direccion", 0.34f);
            }
        }
    }
}
