using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayerNumber : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int players = Mathf.FloorToInt(GetComponent<Slider>().value * 7f) + 1;
        text.text = "Jugadores: " + players;
        PlayerPrefs.SetInt("Players", players);
    }
}
