using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorGeneradorAnzuelo : MonoBehaviour
{
    public Temporizador temporizador;

    List<GameObject> generadoresAnzuelo;

    float tiempoGeneracion;
    float tiempoTranscurrido;

    // Start is called before the first frame update
    void Start()
    {
        generadoresAnzuelo = new List<GameObject>(GameObject.FindGameObjectsWithTag("GeneradorAnzuelo"));
        tiempoGeneracion = temporizador.tiempoInicial / 31;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido >= tiempoGeneracion)
        {
            SpawnBait();
        }
    }

    void SpawnBait()
    {
        tiempoTranscurrido = 0;
        int i = Random.Range(0, generadoresAnzuelo.Count);
        GeneradorAnzuelo generadorAnzuelo = generadoresAnzuelo[i].GetComponent<GeneradorAnzuelo>();
        generadorAnzuelo.SpawnBait();
    }
}
