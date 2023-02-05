using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    public int numberOfPlayers = 1;

    public List<GameObject> players;

    // Start is called before the first frame update
    void Start()
    {
        numberOfPlayers = PlayerPrefs.GetInt("Players");
        int i = 0;
        while (i < numberOfPlayers)
        {
            players[i].SetActive(true);
            i += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
