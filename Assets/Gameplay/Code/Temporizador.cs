using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    public float tiempoInicial = 143;
    public float tiempoRestante = 143;

    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        tiempoRestante = tiempoInicial;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        int minutos = Mathf.FloorToInt(tiempoRestante/60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        if (segundos >= 10) text.text = minutos + ":" + segundos;
        else text.text = minutos + ":" + "0" + segundos;
    }

    public float RatioTiempo()
    {
        return tiempoRestante / tiempoInicial;
    }
}
