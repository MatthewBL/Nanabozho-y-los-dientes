using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvocadorNanabozho : MonoBehaviour
{
    float tiempoComprobacion;
    bool haInvocado;

    public Temporizador temporizador;
    public ZonaDefender zonaDefender;

    public GameObject Nanabozho;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckSummonNanabozho();
    }

    void CheckSummonNanabozho()
    {
        if (!haInvocado && temporizador.RatioTiempo() <= 0.5f)
        {
            tiempoComprobacion -= Time.deltaTime;
            if (tiempoComprobacion <= 0)
            {
                tiempoComprobacion = temporizador.tiempoInicial * 0.1f;
                float probabilidad = 1 - zonaDefender.RatioDefensa();
                float r = Random.Range(0f, 1f);
                if (r <= probabilidad)
                {
                    SummonNanabozho();
                }
            }
        }
    }

    void SummonNanabozho()
    {
        haInvocado = true;
        Instantiate(Nanabozho, transform);
    }
}
