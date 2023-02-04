using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxColor : MonoBehaviour
{
    public enum Hablador { Jugador, Chaman }

    public Color colorJugador;
    public Color colorChaman;

    public Hablador hablador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color color = GetComponent<Image>().color;
        if (hablador == Hablador.Jugador)
        {
            GetComponent<Image>().color = new Color(colorJugador.r, colorJugador.g, colorJugador.b, color.a);
        }
        if (hablador == Hablador.Chaman)
        {
            GetComponent<Image>().color = new Color(colorChaman.r, colorChaman.g, colorChaman.b, color.a);
        }
    }
}
