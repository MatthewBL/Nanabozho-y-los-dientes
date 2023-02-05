using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    public static bool victory = false;

    public float tiempoInicial = 143;
    public float tiempoRestante = 143;

    public TextMeshProUGUI text;
    public GameObject fadeInPanel;

    ContadorAnzuelos contadorAnzuelos;

    // Start is called before the first frame update
    void Start()
    {
        tiempoRestante = tiempoInicial;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        int minutos = Mathf.Max(Mathf.FloorToInt(tiempoRestante / 60), 0);
        int segundos = Mathf.Max(Mathf.FloorToInt(tiempoRestante % 60), 0);
        if (segundos >= 10) text.text = minutos + ":" + segundos;
        else text.text = minutos + ":" + "0" + segundos;

        CheckVictory();
    }

    public float RatioTiempo()
    {
        return tiempoRestante / tiempoInicial;
    }

    void CheckVictory()
    {
        if (tiempoRestante <= 0.5f)
        {
            Temporizador.victory = true;
            fadeInPanel.gameObject.SetActive(true);
        }
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            if (tiempoRestante <= 0f)
            {
                contadorAnzuelos = GameObject.FindGameObjectWithTag("ContadorAnzuelos").GetComponent<ContadorAnzuelos>();

                if (contadorAnzuelos.anzuelosObtenidos >= 23)
                {
                    PlayerPrefs.SetString("Outcome", "Secret");
                }
                else
                {
                    PlayerPrefs.SetString("Outcome", "Victory");
                }
                Temporizador.victory = false;
                SceneManager.LoadScene(2);
            }
        }
        else
        {
            if (tiempoRestante <= 0f)
            {
                Temporizador.victory = false;
                int level = PlayerPrefs.GetInt("SurvivalLevel");
                PlayerPrefs.SetInt("SurvivalLevel", level + 1);
                SceneManager.LoadScene(3);
            }
        }
        
    }
}
