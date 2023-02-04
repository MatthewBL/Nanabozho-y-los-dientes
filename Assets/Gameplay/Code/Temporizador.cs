using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    public float tiempoInicial = 143;
    public float tiempoRestante = 143;

    // Start is called before the first frame update
    void Start()
    {
        tiempoRestante = tiempoInicial;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoRestante -= Time.deltaTime;
    }

    public float RatioTiempo()
    {
        return tiempoRestante / tiempoInicial;
    }
}
