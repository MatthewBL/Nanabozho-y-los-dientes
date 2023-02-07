using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerManagement : NetworkBehaviour
{
    public int numberOfPlayers = 1;

    public List<GameObject> players;

    // Start is called before the first frame update
    void Start()
    {
        if (IsServer)
        {
            numberOfPlayers = NetworkManager.ConnectedClients.Count;
            SpawnPlayers(numberOfPlayers);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void SpawnPlayers(int numberOfPlayers)
    {
        int i = 0;
        while (i < numberOfPlayers)
        {
            GameObject player = Instantiate(players[i], transform);
            player.GetComponent<NetworkObject>().Spawn();
            player.GetComponent<NetworkObject>().ChangeOwnership(Convert.ToUInt64(i));
            i += 1;
        }
    }
}
