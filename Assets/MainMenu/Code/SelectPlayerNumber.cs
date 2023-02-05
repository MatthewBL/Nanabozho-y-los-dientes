using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayerNumber : MonoBehaviour
{
    public List<GameObject> playerUIs;

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

        int i = 0;
        while (i < 8)
        {
            if (i < players)
            {
                playerUIs[i].SetActive(true);
            }
            else
            {
                playerUIs[i].SetActive(false);
            }
            i += 1;
        }
    }
}
