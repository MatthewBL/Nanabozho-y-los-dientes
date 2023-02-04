using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorGeneradorEnemigos : MonoBehaviour
{
    public float tiempoGeneracionInicial = 2;
    public float tiempoGeneracionFinal = 0.05f;
    public float tiempoTranscurrido = 0;

    float tiempoGeneración = 1f;

    List<GameObject> generadoresEnemigos;

    // Start is called before the first frame update
    void Start()
    {
        generadoresEnemigos = new List<GameObject>(GameObject.FindGameObjectsWithTag("GeneradorEnemigos"));
    }

    // Update is called once per frame
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido >= tiempoGeneración)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        tiempoTranscurrido = 0;
        int i = Random.Range(0, generadoresEnemigos.Count);
        GeneradorEnemigo generadorEnemigo = generadoresEnemigos[i].GetComponent<GeneradorEnemigo>();
        generadorEnemigo.SpawnEnemy();
    }
}
