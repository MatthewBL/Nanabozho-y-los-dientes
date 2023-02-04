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

    // Start is called before the first frame update
    void Start()
    {
        tiempoRestante = tiempoInicial;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
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
        if (tiempoRestante <= 0f)
        {
            PlayerPrefs.SetString("Outcome", "Victory");
            SceneManager.LoadScene(2);
        }
    }
}
